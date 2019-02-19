/*
 * @CreateTime: Feb 19, 2019 7:50 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 19, 2019 10:45 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Procurments.PurchaseRecievings.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Stocks.StockLots.Models;
using BionicInventory.Domain.Procurment.PurchaseOrders;
using BionicProduction.Domain.StockBatchs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Procurments.PurchaseRecievings.Commands {
    public class CreatePurchaseRecievingCommandHandler : IRequestHandler<PurchaseRecievingDto, uint> {
        private readonly IInventoryDatabaseService _database;
        private readonly IMediator _Mediator;

        public CreatePurchaseRecievingCommandHandler (IInventoryDatabaseService database,
            IMediator mediator) {
            _database = database;
            _Mediator = mediator;
        }

        public async Task<uint> Handle (PurchaseRecievingDto request, CancellationToken cancellationToken) {
            var purchaseOrder = await _database.PurchaseOrder
                .Include (p => p.StockBatch)
                .Where (p => p.Id == request.PurchaseOrderId)
                .FirstOrDefaultAsync ();

            if (purchaseOrder == null) {
                throw new NotFoundException (nameof (PurchaseOrder), request.PurchaseOrderId);
            }

            foreach (var item in request.RecievedItems) {
                var lot = purchaseOrder.StockBatch.FirstOrDefault (l => l.Id == item.LotId);

                if (lot == null) {
                    throw new NotFoundException (nameof (StockBatch), item.LotId);
                }

                //if recieved amount is equal to total recieved quantity
                if (item.Quantity == lot.Quantity) {
                    lot.Status = "Recieved";
                    lot.ArrivalDate = DateTime.Now;
                    purchaseOrder.Status = "Recieved";

                    // if recieved amount is less than total lot quantity
                } else if (item.Quantity < lot.Quantity && item.Quantity >= 1) {
                    var difference = lot.Quantity - item.Quantity;

                    var storages = await _database.StockBatch
                        .Include (s => s.Item)
                        .Include (s => s.StockBatchStorage)
                        .Where (s => s.Id == lot.Id)
                        .FirstOrDefaultAsync ();

                    await _Mediator.Send (new NewStockBatchDto () {

                        PurchaseOrderId = storages.PurchaseOrderId,
                            ItemId = storages.ItemId,
                            Quantity = difference,
                            Status = "Planed",
                            UnitCost = storages.UnitCost,
                            AvailableFrom = storages.AvailableFrom,
                            StorageLocation = new List<NewStockBatchStorageDto> () {
                                new NewStockBatchStorageDto () {
                                    Quantity = difference,
                                        StorageId = storages.Item.DefaultStorageId
                                }
                            }

                    });

                    storages.Quantity = storages.Quantity - difference;
                    storages.Status = "Recieved";
                    storages.ArrivalDate = DateTime.Now;

                    foreach (var location in storages.StockBatchStorage) {

                        if (location.Quantity > difference) {
                            location.Quantity = location.Quantity - difference;
                            break;
                        }

                        difference = difference - location.Quantity;

                        _database.StockBatchStorage.Remove (location);

                        if (difference == 0) {
                            break;
                        }
                    }

                    _database.StockBatch.Update (storages);

                }

                _database.PurchaseOrder.Update (purchaseOrder);
            }

            await _database.SaveAsync ();

            return purchaseOrder.Id;
        }
    }
}