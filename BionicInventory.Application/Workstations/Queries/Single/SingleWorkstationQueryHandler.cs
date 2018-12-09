/*
 * @CreateTime: Dec 9, 2018 11:36 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 9, 2018 11:51 PM
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
    public class SingleWorkstationQueryHandler : IRequestHandler<SingleWorkstationQuery, WorkstationView> {
        private readonly IInventoryDatabaseService _database;

        public SingleWorkstationQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<WorkstationView> Handle (SingleWorkstationQuery request, CancellationToken cancellationToken) {

            var workstation = await _database.WorkStation
                .Where (w => w.Id == request.Id)
                .Select (WorkstationView.Projection)
                .FirstOrDefaultAsync ();

            if (workstation == null) {
                throw new NotFoundException (nameof (Workstation), request.Id);
            } else {
                return workstation;
            }
        }
    }
}