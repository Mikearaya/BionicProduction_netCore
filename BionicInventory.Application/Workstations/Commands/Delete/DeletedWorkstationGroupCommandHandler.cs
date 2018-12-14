/*
 * @CreateTime: Dec 15, 2018 1:14 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 15, 2018 1:15 AM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Workstations;
using MediatR;

namespace BionicInventory.Application.Workstations.Commands.Delete {
    public class DeletedWorkstationGroupCommandHandler : IRequestHandler<DeletedWorkstationGroupDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public DeletedWorkstationGroupCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeletedWorkstationGroupDto request, CancellationToken cancellationToken) {
            var workstation = await _database.WorkStationGroup.FindAsync (request.Id);

            if (workstation == null) {
                throw new NotFoundException (nameof (WorkstationGroup), request.Id);
            }

            _database.WorkStationGroup.Remove (workstation);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}