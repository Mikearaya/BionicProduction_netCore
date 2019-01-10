/*
 * @CreateTime: Jan 1, 2019 12:12 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 10, 2019 10:22 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Procurments.PurchaseOrders.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Procurment.PurchaseOrders;
using BionicInventory.Domain.Procurment.Vendors;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Procurments.PurchaseOrders.Commands.Create {
    public class CreatePurchaseOrderCommandHandler : IRequestHandler<NewPurchaseOrderDto, uint> {
        private readonly IInventoryDatabaseService _database;

        public CreatePurchaseOrderCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<uint> Handle (NewPurchaseOrderDto request, CancellationToken cancellationToken) {

            var vendor = await _database.Vendor
                .AsNoTracking ()
                .FirstOrDefaultAsync (v => v.Id == request.VendorId);

            if (vendor == null) {
                throw new NotFoundException (nameof (Vendor), request.VendorId);
            }

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
                OrderedDate = request.OrderedDate
            };

            foreach (var item in request.PurchaseOrderItems) {

                var vendorItem = await _database.VendorPurchaseTerm
                    .Include (v => v.Item)
                    .AsNoTracking ()
                    .Where (v => v.Id == request.VendorId && v.ItemId == item.ItemId)
                    .OrderByDescending (v => v.Priority)
                    .FirstOrDefaultAsync ();

                if (vendorItem == null) {
                    throw new NotFoundException ("Vendor Item", item.ItemId);
                }

                purchaseOrder.PurchaseOrderItem.Add (new PurchaseOrderItem () {
                    ItemId = vendorItem.ItemId,
                        Quantity = item.Quantity,
                        ExpectedDate = (item.ExpectedDate == null) ? request.ExpectedDate : (DateTime) item.ExpectedDate,
                        UnitPrice = item.UnitPrice,
                });

            }

            _database.PurchaseOrder.Add (purchaseOrder);
            await _database.SaveAsync ();

            return purchaseOrder.Id;
        }
    }
}