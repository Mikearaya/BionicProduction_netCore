/*
 * @CreateTime: Dec 3, 2018 10:07 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 3, 2018 10:12 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.UnitOfMeasurments;
using MediatR;

namespace BionicInventory.Application.UnitOfMeasurments.Queries {
    public class SingleUnitOfMeasurmentHandler : IRequestHandler<SingleUnitOfMeasurmentQuery, UnitOfMeasurmentView> {
        private readonly IInventoryDatabaseService _database;

        public SingleUnitOfMeasurmentHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<UnitOfMeasurmentView> Handle (SingleUnitOfMeasurmentQuery request, CancellationToken cancellationToken) {
            var uom = await _database.UnitsOfMeasurment
                .FindAsync (request.Id);

            if (uom == null) {
                throw new NotFoundException (nameof (UnitOfMeasurment), request.Id);
            }

            return new UnitOfMeasurmentView () {
                id = uom.Id,
                    name = uom.Name,
                    abbrevation = uom.Abrivation,
                    active = (uom.Active == 1) ? true : false,
                    dateAdded = uom.DateAdded,
                    dateUpdated = uom.DateUpdated
            };
        }
    }
}