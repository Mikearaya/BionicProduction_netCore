/*
 * @CreateTime: Dec 29, 2018 10:52 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 8:40 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Stocks.StockLots.Models;
using BionicProduction.Domain.StockBatchs;
using MediatR;

namespace BionicInventory.Application.Stocks.StockLots.Commands.Update {
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
                batch.Status = "Recieved";
            } else if (request.status.Trim ().ToUpper () == "PLANED" && batch.Status.Trim ().ToUpper () == "RECIEVED") {
                batch.Status = "Planed";
            }

            _database.StockBatch.Update (batch);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}