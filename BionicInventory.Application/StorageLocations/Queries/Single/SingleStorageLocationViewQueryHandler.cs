/*
 * @CreateTime: Dec 13, 2018 12:51 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 13, 2018 12:54 AM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.StorageLocations.Models;
using BionicInventory.Domain.Storages;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.StorageLocations.Queries.Single {
    public class SingleStorageLocationViewQueryHandler : IRequestHandler<SingleStorageLocationViewQuery, StorageLocationView> {
        private readonly IInventoryDatabaseService _database;

        public SingleStorageLocationViewQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<StorageLocationView> Handle (SingleStorageLocationViewQuery request, CancellationToken cancellationToken) {
            var storageLocation = await _database.StorageLocation
                .Where (s => s.Id == request.Id)
                .Select (StorageLocationView.Projection)
                .FirstOrDefaultAsync ();

            if (storageLocation == null) {
                throw new NotFoundException (nameof (StorageLocation), request.Id);
            }

            return storageLocation;
        }
    }
}