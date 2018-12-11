/*
 * @CreateTime: Dec 12, 2018 1:39 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2018 1:46 AM
 * @Description: Modify Here, Please 
 */

using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Workstations;
using MediatR;
namespace BionicInventory.Application.Workstations.Commands.Update {
    public class UpdatedWorkStationCommandHandler : IRequestHandler<UpdatedWorkstationDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public UpdatedWorkStationCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (UpdatedWorkstationDto request, CancellationToken cancellationToken) {
            var workstation = await _database.WorkStation.FindAsync (request.Id);

            if (workstation == null) {
                throw new NotFoundException (nameof (Workstation), request.Id);
            }

            workstation.Title = request.Title;
            workstation.Color = request.Color;
            workstation.CustomHolidays = request.CustomHolidays;
            workstation.CustomeWorkingHoures = request.CustomeWorkingHoures;
            workstation.GroupId = request.GroupId;
            workstation.IsActive = request.IsActive;
            workstation.MaintenanceHours = request.MaintenanceHours;
            workstation.MaintenanceItems = request.MaintenanceItems;
            workstation.HourlyRate = request.HourlyRate;

            _database.WorkStation.Update (workstation);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}