using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Products.BOMs.Queries.Models;
using BionicInventory.Domain.Items.BOMs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Products.BOMs.Queries.Collection {
    public class GetBomItemsListHandler : IRequestHandler<BomViewListQuery, IEnumerable<BomView>> {
        private readonly IInventoryDatabaseService _database;

        public GetBomItemsListHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<BomView>> Handle (BomViewListQuery request, CancellationToken cancellationToken) {
            return await _database.Bom.Select (BomView.Projection).ToListAsync ();

        }
    }
}