/*
 * @CreateTime: Dec 13, 2018 12:44 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 13, 2018 1:09 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.StorageLocations.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.StorageLocations.Queries.Collections {
    public class StorageLocationsListQueryHandler : IRequestHandler<StorageLocationListQuery, IEnumerable<StorageLocationView>> {
        private readonly IInventoryDatabaseService _database;

        public StorageLocationsListQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<StorageLocationView>> Handle (StorageLocationListQuery request, CancellationToken cancellationToken) {

            return await _database.StorageLocation
                .Select (StorageLocationView.Projection)
                .ToListAsync ();

        }
    }
}