/*
 * @CreateTime: Dec 3, 2018 9:23 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 3, 2018 9:23 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.UnitOfMeasurments;
using MediatR;

namespace BionicInventory.Application.UnitOfMeasurments.Commands.Delete {
    public class DeletedUnitOfMeasurmentHandler : IRequestHandler<DeletedUnitOfMeasurmentDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public DeletedUnitOfMeasurmentHandler (IInventoryDatabaseService database) {
            _database = database;
        }
        public Task<Unit> Handle (DeletedUnitOfMeasurmentDto request, CancellationToken cancellationToken) {
            var uom = _database.UnitsOfMeasurment
                .Where (u => u.Id == request.Id)
                .FirstOrDefault ();

            if (uom == null) {
                throw new NotFoundException (nameof (UnitOfMeasurment), request.Id);
            }

            _database.UnitsOfMeasurment.Remove (uom);
            _database.Save ();

            return Unit.Task;
        }
    }
}