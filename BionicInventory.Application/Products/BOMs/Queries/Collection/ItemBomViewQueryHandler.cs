/*
 * @CreateTime: Dec 5, 2018 9:51 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 5, 2018 9:51 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Products.BOMs.Queries.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Items;
using MediatR;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Products.BOMs.Queries.Collection {
    public class ItemBomViewQueryHandler : IRequestHandler<ItemBomViewQuery, IEnumerable<BomView>> {
        private readonly IInventoryDatabaseService _database;

        public ItemBomViewQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<BomView>> Handle (ItemBomViewQuery request, CancellationToken cancellationToken) {
            var item = await _database.Item.FindAsync (request.ItemId);

            if (item == null) {
                throw new NotFoundException (nameof (Item), request.ItemId);
            }

            var itemBoms = await _database.Bom
                .Where (b => b.ItemId == request.ItemId)
                .Select (BomView.Projection)
                .ToListAsync ();

            return itemBoms;
        }
    }
}