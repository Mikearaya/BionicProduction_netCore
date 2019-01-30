/*
 * @CreateTime: Dec 29, 2018 11:05 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 8:39 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Stocks.StockLots.Models;
using BionicProduction.Domain.StockBatchs;
using MediatR;

namespace BionicInventory.Application.Stocks.StockLots.Commands.Delete {
    public class DeleteStockBatchCommandHandler : IRequestHandler<DeletedStockBatchDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public DeleteStockBatchCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeletedStockBatchDto request, CancellationToken cancellationToken) {
            var batch = await _database.StockBatch.FindAsync (request.Id);

            if (batch == null) {
                throw new NotFoundException (nameof (StockBatch), request.Id);
            }

            _database.StockBatch.Remove (batch);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}