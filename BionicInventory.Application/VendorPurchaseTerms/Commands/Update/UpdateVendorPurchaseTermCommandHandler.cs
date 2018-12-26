/*
 * @CreateTime: Dec 24, 2018 12:02 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 26, 2018 9:25 PM
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

namespace BionicInventory.Application.Vendors.PurchaseTerms.Commands.Update {
    public class UpdateVendorPurchaseTermCommandHandler : IRequestHandler<UpdatedVendorPurchaseTermDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public UpdateVendorPurchaseTermCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (UpdatedVendorPurchaseTermDto request, CancellationToken cancellationToken) {

            var updatedTerm = await _database.VendorPurchaseTerm.FindAsync (request.Id);

            if (updatedTerm == null) {
                throw new NotFoundException (nameof (VendorPurchaseTerm), request.Id);
            }

            var vendor = await _database.Vendor
                .AsNoTracking ()
                .FirstOrDefaultAsync (v => v.Id == request.VendorId);

            if (vendor == null) {
                throw new NotFoundException (nameof (Vendor), request.VendorId);
            }

            var item = await _database.Item
                .AsNoTracking ()
                .FirstOrDefaultAsync (v => v.Id == request.ItemId);

            if (vendor == null) {
                throw new NotFoundException (nameof (Item), request.ItemId);
            }

            updatedTerm.MinimumQuantity = request.MinimumQuantity;
            updatedTerm.Leadtime = request.Leadtime;
            updatedTerm.Priority = request.Priority;
            updatedTerm.VendorProductId = request.VendorProductId;
            updatedTerm.UnitPrice = request.UnitPrice;

            _database.VendorPurchaseTerm.Update (updatedTerm);

            await _database.SaveAsync ();

            return Unit.Value;

        }
    }
}