/*
 * @CreateTime: Dec 17, 2018 8:57 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 17, 2018 9:01 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Routings.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Items.Rotings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Routings.Queries.Single {
    public class GetRoutingDetailQueryHandler : IRequestHandler<GetRoutingDetailQuery, RoutingDetailView> {
        private readonly IInventoryDatabaseService _database;

        public GetRoutingDetailQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<RoutingDetailView> Handle (GetRoutingDetailQuery request, CancellationToken cancellationToken) {
            var routingDetail = await _database.Routing
                .Where (r => r.Id == request.Id)
                .Select (RoutingDetailView.Projection)
                .FirstOrDefaultAsync ();

            if (routingDetail == null) {
                throw new NotFoundException (nameof (Routing), request.Id);
            }

            return routingDetail;
        }
    }
}