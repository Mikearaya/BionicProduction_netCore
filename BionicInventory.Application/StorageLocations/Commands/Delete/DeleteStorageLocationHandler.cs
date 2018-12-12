/*
 * @CreateTime: Dec 13, 2018 12:31 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 13, 2018 12:33 AM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Storages;
using MediatR;

namespace BionicInventory.Application.StorageLocations.Commands.Delete {
    public class DeleteStorageLocationHandler : IRequestHandler<DeletedStorageLocationDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public DeleteStorageLocationHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeletedStorageLocationDto request, CancellationToken cancellationToken) {
            var storage = await _database.StorageLocation.FindAsync (request.Id);

            if (storage == null) {
                throw new NotFoundException (nameof (StorageLocation), request.Id);
            }

            _database.StorageLocation.Remove (storage);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}