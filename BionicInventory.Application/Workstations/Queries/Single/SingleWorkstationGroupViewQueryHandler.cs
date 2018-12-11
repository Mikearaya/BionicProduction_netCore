/*
 * @CreateTime: Dec 12, 2018 2:03 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2018 2:08 AM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Workstations.Models;
using BionicInventory.Domain.Workstations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Workstations.Queries.Single {
    public class SingleWorkstationGroupViewQueryHandler : IRequestHandler<SingleWorkstationGroupViewQuery, WorkstationGroupDetailView> {
        private readonly IInventoryDatabaseService _database;

        public SingleWorkstationGroupViewQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<WorkstationGroupDetailView> Handle (SingleWorkstationGroupViewQuery request, CancellationToken cancellationToken) {
            var workstationGroup = await _database.WorkStationGroup
                .Where (w => w.Id == request.Id)
                .Select (WorkstationGroupDetailView.Projection)
                .FirstOrDefaultAsync ();

            if (workstationGroup == null) {
                throw new NotFoundException (nameof (WorkstationGroup), request.Id);
            }

            return workstationGroup;
        }
    }
}