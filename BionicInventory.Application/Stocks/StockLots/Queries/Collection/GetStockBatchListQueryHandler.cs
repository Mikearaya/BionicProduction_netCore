/*
 * @CreateTime: Dec 30, 2018 7:50 PM
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
    public class GetStockBatchListQueryHandler : IRequestHandler<GetStockBatchListQuery, IEnumerable<StockBatchListView>> {
        private readonly IInventoryDatabaseService _database;

        public GetStockBatchListQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<StockBatchListView>> Handle (GetStockBatchListQuery request, CancellationToken cancellationToken) {
            return await _database.StockBatchStorage.Select (StockBatchListView.Projection).ToListAsync ();
        }
    }
}