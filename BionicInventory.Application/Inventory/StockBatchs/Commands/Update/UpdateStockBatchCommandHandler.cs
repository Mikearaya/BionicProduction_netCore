/*
 * @CreateTime: Dec 29, 2018 10:52 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 29, 2018 11:03 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Inventory.StockBatchs.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicProduction.Domain.StockBatchs;
using MediatR;

namespace BionicInventory.Application.Inventory.StockBatchs.Commands.Update {
    public class UpdateStockBatchCommandHandler : IRequestHandler<UpdatedStockBatchDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public UpdateStockBatchCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (UpdatedStockBatchDto request, CancellationToken cancellationToken) {
            var batch = await _database.StockBatch.FindAsync (request.Id);

            if (batch == null) {
                throw new NotFoundException (nameof (StockBatch), request.Id);
            }

            batch.AvailableFrom = request.AvailableFrom;
            batch.ExpiryDate = request.ExpiryDate;

            if (request.status.Trim ().ToUpper () == "RECIEVED" && batch.Status.Trim ().ToUpper () != "RECIEVED") {
                batch.ArrivalDate = DateTime.Now;
            }

            _database.StockBatch.Update (batch);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}