/*
 * @CreateTime: Dec 12, 2018 1:50 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2018 1:52 AM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Workstations;
using MediatR;

namespace BionicInventory.Application.Workstations.Commands.Delete {
    public class DeletedWorkstationCommandHandler : IRequestHandler<DeletedWorkstationDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public DeletedWorkstationCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeletedWorkstationDto request, CancellationToken cancellationToken) {
            var workstation = await _database.WorkStation.FindAsync (request.Id);

            if (workstation == null) {
                throw new NotFoundException (nameof (Workstation), request.Id);
            }

            _database.WorkStation.Remove (workstation);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}