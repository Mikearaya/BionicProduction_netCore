/*
 * @CreateTime: Dec 9, 2018 11:57 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2018 3:24 AM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Workstations;
using MediatR;

namespace BionicInventory.Application.Workstations.Commands.Create {
    public class NewWorkstationCommandHandler : IRequestHandler<NewWorkstationDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public NewWorkstationCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (NewWorkstationDto request, CancellationToken cancellationToken) {

            var workstationGroup = await _database.WorkStationGroup.FindAsync (request.GroupId);

            if (workstationGroup == null) {
                throw new NotFoundException (nameof (WorkstationGroup), request.GroupId);
            }

            for (var i = 0; i < request.instances; i++) {
                _database.WorkStation.Add (new Workstation () {
                    Title = request.Title,
                        HolidayHours = request.HolidayHours,
                        WorkingHours = request.WorkingHours,
                        IsActive = request.IsActive,
                        Color = request.Color,
                        HourlyRate = request.HourlyRate,
                        MaintenanceItems = request.MaintenanceItems,
                        MaintenanceHours = request.MaintenanceHours,
                        Productivity = request.Productivity,
                        GroupId = request.GroupId

                });
            }

            await _database.SaveAsync ();

            return Unit.Value;

        }
    }
}