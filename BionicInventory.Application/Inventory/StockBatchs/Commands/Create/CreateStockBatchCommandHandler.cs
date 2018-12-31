/*
 * @CreateTime: Dec 27, 2018 11:48 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 30, 2018 9:03 PM
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
using BionicInventory.Domain.Procurment.PurchaseOrders;
using BionicInventory.Domain.ProductionOrders;
using BionicProduction.Domain.StockBatchs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Inventory.StockBatchs.Commands.Create {
    public class CreateStockBatchCommandHandler : IRequestHandler<NewStockBatchDto, uint> {
        private readonly IInventoryDatabaseService _database;

        public CreateStockBatchCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<uint> Handle (NewStockBatchDto request, CancellationToken cancellationToken) {

            var item = await _database.Item
                .AsNoTracking ()
                .FirstOrDefaultAsync (i => i.Id == request.ItemId);

            if (item == null) {
                throw new NotFoundException (nameof (Item), request.ItemId);
            }

            StockBatch batch = new StockBatch () {
                ItemId = request.ItemId,
                Quantity = request.Quantity,
                UnitCost = request.UnitCost,
                AvailableFrom = request.AvailableFrom,
                Status = request.Status
            };
            batch.Source = "Manual";
            Object manufacture;
            // check if manufacture order id is defined
            if (request.ManufactureOrderId != null && request.ManufactureOrderId != 0) {
                manufacture = await _database.ProductionOrderList
                    .AsNoTracking ()
                    .FirstOrDefaultAsync (m => m.Id == request.ManufactureOrderId);

                if (manufacture == null) {
                    throw new NotFoundException (nameof (ProductionOrderList), request.ManufactureOrderId);
                }
                batch.Source = "Manufactured";
                batch.ManufactureOrderId = request.ManufactureOrderId;
            }

            Object purchaseOrder;
            // check if purchase order id is defined
            if (request.PurchaseOrderId != null && request.PurchaseOrderId != 0) {
                purchaseOrder = await _database.PurchaseOrder
                    .AsNoTracking ()
                    .FirstOrDefaultAsync (p => p.Id == request.PurchaseOrderId);

                if (purchaseOrder == null) {
                    throw new NotFoundException (nameof (PurchaseOrder), request.PurchaseOrderId);
                }
                batch.Source = "Procured";
                batch.PurchaseOrderId = request.PurchaseOrderId;
            }

            if (request.ExpiryDate != null) {
                batch.ExpiryDate = request.ExpiryDate;
            } else if (item.ShelfLife != 0 && item.ShelfLife != null) {
                batch.ExpiryDate = request.AvailableFrom.AddDays ((double) item.ShelfLife);
            }

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

    }
}