/*
 * @CreateTime: Jan 4, 2019 8:23 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 8:42 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Stocks.StockLots.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Stocks.StockLots.Queries.Collection {
    public class GetItemStockBatchsQueryHandler : IRequestHandler<GetItemStockBatchsQuery, IEnumerable<StockLotView>> {
        private readonly IInventoryDatabaseService _database;

        public GetItemStockBatchsQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<StockLotView>> Handle (GetItemStockBatchsQuery request, CancellationToken cancellationToken) {
            return await _database.StockBatchStorage
                .Where (lot => lot.Batch.ItemId == request.ItemId)
                .Select (StockLotView.Projection)
                .ToListAsync ();
        }
    }
}