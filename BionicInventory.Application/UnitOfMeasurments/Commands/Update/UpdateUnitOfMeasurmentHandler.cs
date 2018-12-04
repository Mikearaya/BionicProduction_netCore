/*
 * @CreateTime: Dec 4, 2018 12:48 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 4, 2018 7:54 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.UnitOfMeasurments.Models;
using BionicInventory.Domain.UnitOfMeasurments;
using MediatR;

namespace BionicInventory.Application.UnitOfMeasurments.Commands.Update {
    public class UpdateUnitOfMeasurmentHandler : IRequestHandler<UpdatedUnitOfMeasurmentDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public UpdateUnitOfMeasurmentHandler (IInventoryDatabaseService database) {
            _database = database;
        }
        public async Task<Unit> Handle (UpdatedUnitOfMeasurmentDto request, CancellationToken cancellationToken) {
            var uom = await _database.UnitsOfMeasurment
                .FindAsync (request.Id);

            if (uom == null) {
                throw new NotFoundException (nameof (UnitOfMeasurment), request.Id);
            }

            uom.Abrivation = request.Abrivation;
            uom.Name = request.Name;
            uom.Active = request.Active;

            _database.UnitsOfMeasurment.Update (uom);
            await _database.SaveAsync ();

            return Unit.Value;

        }
    }
}