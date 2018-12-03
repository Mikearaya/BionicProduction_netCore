using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.UnitOfMeasurments;
using MediatR;

namespace BionicInventory.Application.UnitOfMeasurments.Commands.Update {
    public class UpdateUnitOfMeasurmentHandler : IRequestHandler<UpdatedUnitOfMeasurmentDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public UpdateUnitOfMeasurmentHandler (IInventoryDatabaseService database) {
            _database = database;
        }
        Task<Unit> IRequestHandler<UpdatedUnitOfMeasurmentDto, Unit>.Handle (UpdatedUnitOfMeasurmentDto request, CancellationToken cancellationToken) {
            var uom = _database.UnitsOfMeasurment
                .Where (u => u.Id == request.Id)
                .FirstOrDefault ();

            if (uom == null) {
                throw new NotFoundException (nameof (UnitOfMeasurment), request.Id);
            }

            uom.Abrivation = request.Abrivation;
            uom.Name = request.Name;
            uom.Active = request.Active;

            _database.UnitsOfMeasurment.Update (uom);
            _database.Save ();

            return Unit.Task;

        }
    }
}