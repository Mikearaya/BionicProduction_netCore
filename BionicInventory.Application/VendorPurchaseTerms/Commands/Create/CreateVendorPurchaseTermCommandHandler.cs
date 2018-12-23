/*
 * @CreateTime: Dec 23, 2018 11:51 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 24, 2018 12:00 AM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Items;
using BionicInventory.Domain.Vendors;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Vendors.PurchaseTerms.Commands.Create {
    public class CreateVendorPurchaseTermCommandHandler : IRequestHandler<NewVendorPurchaseTermDto, uint> {
        private readonly IInventoryDatabaseService _database;

        public CreateVendorPurchaseTermCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<uint> Handle (NewVendorPurchaseTermDto request, CancellationToken cancellationToken) {

            var vendor = _database.Vendor
                .AsNoTracking ()
                .FirstOrDefaultAsync (v => v.Id == request.VendorId);

            if (vendor == null) {
                throw new NotFoundException (nameof (Vendor), request.VendorId);
            }
            var item = await _database.Item
                .AsNoTracking ()
                .FirstOrDefaultAsync (i => i.Id == request.ItemId);

            if (item == null) {
                throw new NotFoundException (nameof (Item), request.ItemId);
            }

            VendorPurchaseTerm newTerm = new VendorPurchaseTerm () {
                VendorId = request.VendorId,
                ItemId = request.ItemId,
                VendorProductId = request.VendorProductId,
                MinimumQuantity = request.MinimumQuantity,
                Leadtime = request.Leadtime,
                Priority = request.Priority,
                UnitPrice = request.UnitPrice
            };

            _database.VendorPurchaseTerm.Add (newTerm);

            await _database.SaveAsync ();

            return newTerm.Id;
        }
    }
}