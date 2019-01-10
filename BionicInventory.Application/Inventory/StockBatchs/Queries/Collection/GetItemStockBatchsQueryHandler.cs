/*
 * @CreateTime: Jan 4, 2019 8:23 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 10, 2019 8:20 PM
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
    public class GetItemStockBatchsQueryHandler : IRequestHandler<GetItemStockBatchsQuery, IEnumerable<StockLotView>> {
        private readonly IInventoryDatabaseService _database;

        public GetItemStockBatchsQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<StockLotView>> Handle (GetItemStockBatchsQuery request, CancellationToken cancellationToken) {
            return await _database.StockBatch
                .Where (lot => lot.ItemId == request.ItemId)
                .Select (StockLotView.Projection)
                .ToListAsync ();
        }
    }
}