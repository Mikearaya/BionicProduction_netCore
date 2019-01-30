/*
 * @CreateTime: Jan 30, 2019 7:51 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 7:53 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Stocks.Items.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Stocks.Items.Queries.Collections {
    public class GetItemsListQueryHandler : IRequestHandler<GetItemsLIstQuery, IEnumerable<ItemView>> {
        private readonly IInventoryDatabaseService _database;

        public GetItemsListQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<ItemView>> Handle (GetItemsLIstQuery request, CancellationToken cancellationToken) {
            return await _database.Item
                .Select (ItemView.Projection)
                .ToListAsync ();
        }
    }
}