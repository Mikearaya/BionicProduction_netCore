/*
 * @CreateTime: Dec 13, 2018 12:21 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 13, 2018 12:24 AM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Domain.Storages;
using MediatR;

namespace BionicInventory.Application.StorageLocations.Commands.Create {
    public class CreateNewStorageLocationHandler : IRequestHandler<NewStorageLocationDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public CreateNewStorageLocationHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (NewStorageLocationDto request, CancellationToken cancellationToken) {

            _database.StorageLocation.Add (new StorageLocation () {
                Name = request.Name,
                    Note = request.Note,
                    Active = request.Active
            });

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}