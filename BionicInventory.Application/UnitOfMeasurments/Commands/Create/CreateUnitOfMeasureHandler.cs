using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Domain.UnitOfMeasurments;
using MediatR;

namespace BionicInventory.Application.UnitOfMeasurments.Commands.Create {
    public class CreateUnitOfMeasureHandler : IRequestHandler<NewUnitOfMeasureDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public CreateUnitOfMeasureHandler (IInventoryDatabaseService database) {
            _database = database;
        }
        public async Task<Unit> Handle (NewUnitOfMeasureDto request, CancellationToken cancellationToken) {
            UnitOfMeasurment newUnit = new UnitOfMeasurment () {
                Name = request.Name,
                Abrivation = request.Abrivation,
                Active = request.Active 
            };
            _database.UnitsOfMeasurment.Add (newUnit);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}