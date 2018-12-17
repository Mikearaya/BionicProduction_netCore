/*
 * @CreateTime: Dec 17, 2018 9:50 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 17, 2018 9:59 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Routings.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Items;
using BionicInventory.Domain.Items.Rotings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Routings.Queries.Single {
    public class GetProductRoutingListQueryHandler : IRequestHandler<GetProductRoutingListQuery, IEnumerable<RoutingView>> {
        private readonly IInventoryDatabaseService _database;

        public GetProductRoutingListQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<RoutingView>> Handle (GetProductRoutingListQuery request, CancellationToken cancellationToken) {

            var item = await _database.Item.FindAsync (request.ItemId);

            if (item == null) {
                throw new NotFoundException (nameof (Item), request.ItemId);
            }

            var itemRoutings = await _database.Routing
                .Where (r => r.ItemId == request.ItemId)
                .Select (RoutingView.Projection)
                .ToListAsync ();

            return itemRoutings;
        }
    }
}