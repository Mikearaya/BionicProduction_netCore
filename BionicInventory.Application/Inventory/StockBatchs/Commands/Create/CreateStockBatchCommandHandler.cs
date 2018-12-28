/*
 * @CreateTime: Dec 27, 2018 11:48 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 28, 2018 10:31 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Inventory.StockBatchs.Models;
using BionicInventory.Application.Shared;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Items;
using BionicInventory.Domain.ProductionOrders;
using BionicProduction.Domain.StockBatchs;
using MediatR;

namespace BionicInventory.Application.Inventory.StockBatchs.Commands.Create {
    public class CreateStockBatchCommandHandler : IRequestHandler<NewStockBatchDto, uint> {
        private readonly IInventoryDatabaseService _database;

        public CreateStockBatchCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<uint> Handle (NewStockBatchDto request, CancellationToken cancellationToken) {

            var item = await _database.Item.FindAsync (request.ItemId);

            if (item == null) {
                throw new NotFoundException (nameof (Item), request.ItemId);
            }

            Object manufacture;
            if (request.ManufactureOrderId != null && request.ManufactureOrderId != 0) {
                manufacture = await _database.ProductionOrderList.FindAsync (request.ManufactureOrderId);

                if (manufacture == null) {
                    throw new NotFoundException (nameof (ProductionOrderList), request.ManufactureOrderId);
                }
            }

            // TODO: Handle if purchase order is not defined exception

            StockBatch batch = new StockBatch () {
                ItemId = request.ItemId,
                Quantity = request.Quantity,
                UnitCost = request.UnitCost,
                PurchaseOrderId = request.PurchaseOrderId,
                ManufactureOrderId = request.ManufactureOrderId,
                AvailableFrom = request.AvailableFrom,
                ExpiryDate = request.ExpiryDate
            };

            if (request.StorageLocation.Count < 1) {
                throw new BelowRequiredMinimumItemException ("Stock Batch", 1, "Storage Location");
            }

            float storedQuantity = 0;
            foreach (var data in request.StorageLocation) {
                storedQuantity += data.Quantity;

                var store = await _database.StorageLocation.FindAsync (data.StorageId);

                if (store == null) {
                    throw new NotFoundException (nameof (StorageLocations), data.StorageId);
                }

                batch.StockBatchStorage.Add (new StockBatchStorage () {
                    StorageId = store.Id,
                        Quantity = data.Quantity
                });

            }

            // check if the sum of items allocated on each storage matchs the quantity stored in main 
            if (request.Quantity != storedQuantity) {
                throw new InequalMasterDetailQuantityException ("Item Batch", request.Quantity, storedQuantity);
            }

            _database.StockBatch.Add (batch);

            await _database.SaveAsync ();

            return batch.Id;

        }

        private object PurchaseOrderList () {
            throw new NotImplementedException ();
        }
    }
}