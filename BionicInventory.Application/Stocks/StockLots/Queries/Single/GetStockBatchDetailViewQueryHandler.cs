/*
 * @CreateTime: Dec 30, 2018 8:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 8:44 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Stocks.StockLots.Models;
using BionicInventory.Application.Stocks.StockLots.Queries.Collection;
using BionicProduction.Domain.StockBatchs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Stocks.StockLots.Queries.Single {
    public class GetStockBatchDetailViewQueryHandler : IRequestHandler<GetStockBatchDetailViewQuery, StockBatchDetailView> {
        private readonly IInventoryDatabaseService _database;

        public GetStockBatchDetailViewQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<StockBatchDetailView> Handle (GetStockBatchDetailViewQuery request, CancellationToken cancellationToken) {

            var stockBatch = await _database.StockBatch
                .Where (s => s.Id == request.Id)
                .Select (StockBatchDetailView.Projection)
                .FirstOrDefaultAsync ();

            if (stockBatch == null) {
                throw new NotFoundException (nameof (StockBatch), request.Id);
            }

            return stockBatch;
        }
    }
}