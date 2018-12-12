/*
 * @CreateTime: Dec 13, 2018 12:27 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 13, 2018 12:30 AM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Storages;
using MediatR;

namespace BionicInventory.Application.StorageLocations.Commands.Update {
    public class UpdateStorageLocationHandler : IRequestHandler<UpdatedStorageLocationDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public UpdateStorageLocationHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (UpdatedStorageLocationDto request, CancellationToken cancellationToken) {
            var storage = await _database.StorageLocation.FindAsync (request.Id);

            if (storage == null) {
                throw new NotFoundException (nameof (StorageLocation), request.Id);
            }

            storage.Name = request.Name;
            storage.Note = request.Note;
            storage.Active = request.Active;

            _database.StorageLocation.Update (storage);

            await _database.SaveAsync ();

            return Unit.Value;

        }
    }
}