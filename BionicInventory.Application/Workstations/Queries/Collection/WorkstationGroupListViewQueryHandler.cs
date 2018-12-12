/*
 * @CreateTime: Dec 12, 2018 2:28 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2018 2:40 AM
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
    public class WorkstationGroupListViewQueryHandler : IRequestHandler<WorkstationGroupListQuery, IEnumerable<WorkstationGroupView>> {
        private readonly IInventoryDatabaseService _database;

        public WorkstationGroupListViewQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<WorkstationGroupView>> Handle (WorkstationGroupListQuery request, CancellationToken cancellationToken) {
            var workstationGroups = await _database.WorkStationGroup
                .Select (WorkstationGroupView.Projection)
                .ToListAsync ();

            return workstationGroups;
        }
    }
}