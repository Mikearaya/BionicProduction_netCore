/*
 * @CreateTime: Dec 17, 2018 12:46 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 17, 2018 1:00 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Routings.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Routings.Queries.Collections {
    public class GetRoutingListQueryHandler : IRequestHandler<GetRoutingListQuery, IEnumerable<RoutingView>> {
        private readonly IInventoryDatabaseService _database;

        public GetRoutingListQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<RoutingView>> Handle (GetRoutingListQuery request, CancellationToken cancellationToken) {
            return await _database.Routing
                .Select (RoutingView.Projection)
                .ToListAsync ();
        }
    }
}