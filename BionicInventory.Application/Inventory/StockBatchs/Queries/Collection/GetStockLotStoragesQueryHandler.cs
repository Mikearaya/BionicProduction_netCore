/*
 * @CreateTime: Jan 10, 2019 8:08 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 10, 2019 8:14 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Inventory.StockBatchs.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicProduction.Domain.StockBatchs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Inventory.StockBatchs.Queries.Collection {
    public class GetStockLotStoragesQueryHandler : IRequestHandler<GetStockLotStoragesQuery, IEnumerable<StockLotStorageView>> {
        private readonly IInventoryDatabaseService _database;

        public GetStockLotStoragesQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<StockLotStorageView>> Handle (GetStockLotStoragesQuery request, CancellationToken cancellationToken) {

            var lot = await _database.StockBatch.FindAsync (request.LotId);

            if (lot == null) {
                throw new NotFoundException (nameof (StockBatch), request.LotId);
            }
            var lotStorage = await _database.StockBatchStorage
                .Where (storage => storage.BatchId == request.LotId)
                .Select (StockLotStorageView.Projection)
                .ToListAsync ();

            return lotStorage;
        }
    }
}