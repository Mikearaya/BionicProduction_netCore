/*
 * @CreateTime: Dec 9, 2018 11:39 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 9, 2018 11:46 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Workstations.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Workstations.Queries.Collection {
    public class WorkstationListQueryHandler : IRequestHandler<WorkstationListQuery, IEnumerable<WorkstationView>> {
        private readonly IInventoryDatabaseService _database;

        public WorkstationListQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<WorkstationView>> Handle (WorkstationListQuery request, CancellationToken cancellationToken) {

            var workstations = await _database.WorkStation
                .Select (WorkstationView.Projection)
                .ToListAsync ();

            return workstations;
        }
    }
}