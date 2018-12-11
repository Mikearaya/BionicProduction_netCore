/*
 * @CreateTime: Dec 12, 2018 1:47 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2018 1:47 AM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Workstations;
using MediatR;

namespace BionicInventory.Application.Workstations.Commands.Update {
    public class UpdatedWorkstationGroupCommandHandler : IRequestHandler<UpdatedWorkStationGroupDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public UpdatedWorkstationGroupCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (UpdatedWorkStationGroupDto request, CancellationToken cancellationToken) {
            var workstationGroup = await _database.WorkStationGroup.FindAsync (request.Id);

            if (workstationGroup == null) {
                throw new NotFoundException (nameof (WorkstationGroup), request.Id);
            }

            workstationGroup.Name = request.Name;
            workstationGroup.Active = request.Active;
            workstationGroup.Description = request.Description;

            _database.WorkStationGroup.Update (workstationGroup);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}