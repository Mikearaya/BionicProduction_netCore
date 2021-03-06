/*
 * @CreateTime: Jan 1, 2019 12:12 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 18, 2019 8:28 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Procurments.PurchaseOrders.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Stocks.StockLots.Models;
using BionicInventory.Domain.Procurment.PurchaseOrders;
using BionicInventory.Domain.Procurment.Vendors;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Procurments.PurchaseOrders.Commands.Create {
    public class CreatePurchaseOrderCommandHandler : IRequestHandler<NewPurchaseOrderDto, uint> {
        private readonly IInventoryDatabaseService _database;
        private readonly IMediator _Mediator;

        public CreatePurchaseOrderCommandHandler (IInventoryDatabaseService database,
            IMediator mediator) {
            _database = database;
            _Mediator = mediator;
        }

        public async Task<uint> Handle (NewPurchaseOrderDto request, CancellationToken cancellationToken) {

            var vendor = await _database.Vendor
                .AsNoTracking ()
                .FirstOrDefaultAsync (v => v.Id == request.VendorId);

            if (vendor == null) {
                throw new NotFoundException (nameof (Vendor), request.VendorId);
            }

            bool Recieved = false;

            PurchaseOrder purchaseOrder = new PurchaseOrder () {
                VendorId = request.VendorId,
                AdditionalFee = request.AdditionalFee,
                Discount = request.Discount,
                InvoiceDate = request.InvoiceDate,
                Tax = request.Tax,
                InvoiceId = request.InvoiceId,
                ExpectedDate = request.ExpectedDate,
                OrderId = request.OrderId,
                Status = request.Status,
                ShippedDate = request.ShippedDate,
                PaymentDate = request.PaymentDate,
                OrderedDate = request.OrderedDate,

            };

            if (request.OrderedDate != null) {
                purchaseOrder.Status = "Ordered";
            }

            if (request.ShippedDate != null) {
                purchaseOrder.Status = "Shipped";
            }

            if (request.ArivalDate != null) {
                purchaseOrder.Status = "Recieved";
                Recieved = true;
            }

            _database.PurchaseOrder.Add (purchaseOrder);
            await _database.SaveAsync ();

            foreach (var item in request.PurchaseOrderItems) {
                // check if the selected vendor item exists
                var vendorItem = await _database.VendorPurchaseTerm
                    .Include (v => v.Item)
                    .AsNoTracking ()
                    .Where (v => v.VendorId == request.VendorId && v.ItemId == item.ItemId)
                    .OrderByDescending (v => v.Priority)
                    .FirstOrDefaultAsync ();

                if (vendorItem == null) {
                    throw new NotFoundException ("Vendor Item", item.ItemId);
                }

                await _Mediator.Send (new NewStockBatchDto () {

                    PurchaseOrderId = purchaseOrder.Id,
                        ItemId = vendorItem.ItemId,
                        Quantity = item.Quantity,
                        Status = Recieved ? "Recieved" : "Planed",
                        UnitCost = item.UnitPrice,
                        AvailableFrom = (item.ExpectedDate == null) ? request.ExpectedDate : (DateTime) item.ExpectedDate,
                        StorageLocation = new List<NewStockBatchStorageDto> () {
                            new NewStockBatchStorageDto () {
                                Quantity = item.Quantity,
                                    StorageId = vendorItem.Item.DefaultStorageId
                            }
                        }

                });

            }


            return purchaseOrder.Id;
        }
    }
}