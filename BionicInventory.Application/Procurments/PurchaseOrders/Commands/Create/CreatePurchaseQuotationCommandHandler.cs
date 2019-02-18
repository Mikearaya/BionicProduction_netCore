/*
 * @CreateTime: Feb 18, 2019 9:49 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 18, 2019 9:55 PM
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
    public class CreatePurchaseQuotationCommandHandler : IRequestHandler<NewPurchaseQuotationDto, uint> {
        private readonly IInventoryDatabaseService _database;

        public CreatePurchaseQuotationCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<uint> Handle (NewPurchaseQuotationDto request, CancellationToken cancellationToken) {
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
                Tax = request.Tax,
                ExpectedDate = request.ExpectedDate,
                Status = "RFQ",

            };

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

                purchaseOrder.PurchaseOrderQuotation.Add (new PurchaseOrderQuotation () {
                    ItemId = vendorItem.ItemId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        ExpectedDate = (item.ExpectedDate == null) ? request.ExpectedDate : (DateTime) item.ExpectedDate,
                });

            }

            _database.PurchaseOrder.Add (purchaseOrder);
            await _database.SaveAsync ();

            return purchaseOrder.Id;
        }
    }

}