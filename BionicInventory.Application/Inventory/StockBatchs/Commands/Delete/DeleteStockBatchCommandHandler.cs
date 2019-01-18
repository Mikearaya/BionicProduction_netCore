/*
 * @CreateTime: Dec 29, 2018 11:05 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 29, 2018 11:08 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Inventory.StockBatchs.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicProduction.Domain.StockBatchs;
using MediatR;

namespace BionicInventory.Application.Inventory.StockBatchs.Commands.Delete {
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