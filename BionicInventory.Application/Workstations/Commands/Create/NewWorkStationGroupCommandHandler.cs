/*
 * @CreateTime: Dec 12, 2018 1:31 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2018 1:31 AM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Domain.Workstations;
using MediatR;

namespace BionicInventory.Application.Workstations.Commands.Create {
    public class NewWorkStationGroupCommandHandler : IRequestHandler<NewWorkStationGroupDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public NewWorkStationGroupCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (NewWorkStationGroupDto request, CancellationToken cancellationToken) {

            _database.WorkStationGroup.Add (new WorkstationGroup () {
                Name = request.Name,
                    Active = request.Active,
                    Description = request.Description
            });
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}