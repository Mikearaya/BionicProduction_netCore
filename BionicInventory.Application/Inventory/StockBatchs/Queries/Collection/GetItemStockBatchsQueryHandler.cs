/*
 * @CreateTime: Jan 4, 2019 8:23 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 4, 2019 8:25 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Inventory.StockBatchs.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Inventory.StockBatchs.Queries.Collection {
    public class GetItemStockBatchsQueryHandler : IRequestHandler<GetItemStockBatchsQuery, IEnumerable<StockBatchListView>> {
        private readonly IInventoryDatabaseService _database;

        public GetItemStockBatchsQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<StockBatchListView>> Handle (GetItemStockBatchsQuery request, CancellationToken cancellationToken) {
            return await _database.StockBatchStorage
                .Where (batch_storage => batch_storage.Batch.ItemId == request.ItemId)
                .Select (StockBatchListView.Projection)
                .ToListAsync ();
        }
    }
}