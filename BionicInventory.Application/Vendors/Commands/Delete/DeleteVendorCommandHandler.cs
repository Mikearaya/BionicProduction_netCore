/*
 * @CreateTime: Dec 23, 2018 11:22 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 29, 2018 9:57 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Procurment.Vendors;
using MediatR;

namespace BionicInventory.Application.Vendors.Commands.Delete {
    public class DeleteVendorCommandHandler : IRequestHandler<DeletedVendorDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public DeleteVendorCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeletedVendorDto request, CancellationToken cancellationToken) {
            var vendor = await _database.Vendor.FindAsync (request.Id);

            if (vendor == null) {
                throw new NotFoundException (nameof (Vendor), request.Id);
            }

            _database.Vendor.Remove (vendor);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}