/*
 * @CreateTime: Dec 24, 2018 12:11 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 24, 2018 12:13 AM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Vendors;
using MediatR;

namespace BionicInventory.Application.Vendors.PurchaseTerms.Commands.Delete {
    public class DeleteVendorPurchaseTermCommandHandler : IRequestHandler<DeletedVendorPurchaseTermDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public DeleteVendorPurchaseTermCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeletedVendorPurchaseTermDto request, CancellationToken cancellationToken) {
            var term = await _database.VendorPurchaseTerm.FindAsync (request.Id);

            if (term == null) {
                throw new NotFoundException (nameof (VendorPurchaseTerm), request.Id);
            }

            _database.VendorPurchaseTerm.Remove (term);

            await _database.SaveAsync ();

            return Unit.Value;

        }
    }
}