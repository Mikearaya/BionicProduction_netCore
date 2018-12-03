/*
 * @CreateTime: Dec 3, 2018 10:14 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 3, 2018 10:39 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.UnitOfMeasurments.Queries {
    public class UnitOfMeasurmentListQueryHandler : IRequestHandler<UnitOfMeasurmentListQuery, IEnumerable<UnitOfMeasurmentView>> {
        private readonly IInventoryDatabaseService _database;

        public UnitOfMeasurmentListQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<UnitOfMeasurmentView>> Handle (UnitOfMeasurmentListQuery request, CancellationToken cancellationToken) {
            var uom = await _database.UnitsOfMeasurment.Select (u =>
                new UnitOfMeasurmentView {
                    id = u.Id,
                        name = u.Name,
                        abbrevation = u.Abrivation,
                        active = (u.Active == 1) ? true : false,
                        dateAdded = u.DateAdded,
                        dateUpdated = u.DateUpdated
                }).ToListAsync ();

            return uom;
        }
    }
}