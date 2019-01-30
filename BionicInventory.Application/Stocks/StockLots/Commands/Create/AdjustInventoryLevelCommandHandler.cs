using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Stocks.StockLots.Models;
using BionicInventory.Domain.Items;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Stocks.StockLots.Commands.Create {
    public class AdjustInventoryLevelCommandHandler : IRequestHandler<InventoryAdjustmentDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public IMediator _Mediator { get; }

        public AdjustInventoryLevelCommandHandler (IInventoryDatabaseService database,
            IMediator mediator) {
            _database = database;
            _Mediator = mediator;
        }

        public async Task<Unit> Handle (InventoryAdjustmentDto request, CancellationToken cancellationToken) {

            var item = await _database.Item.FindAsync (request.ItemId);

            if (item == null) {
                throw new NotFoundException (nameof (Item), request.ItemId);
            }

            var totalInventory = await _database.StockBatchStorage
                .Include (a => a.Batch)
                .Include (b => b.WriteOffDetail)
                .Where (storage => storage.Batch.ItemId == request.ItemId)
                .ToListAsync ();

            var quantity = totalInventory
                .Where (b => b.Batch.Status.Trim ().ToUpper () == "RECIEVED")
                .GroupBy (d => d.Batch.ItemId)
                .Sum (i => i.Sum (f => f.Quantity - f.WriteOffDetail.Sum (s => s.Quantity)));

            if (quantity > request.NewQuantity) {
                Console.WriteLine ("its a write off");
            }

            if (quantity < request.NewQuantity) {

                var lastLot = await _database.StockBatch
                    .FirstOrDefaultAsync (lot => lot.ItemId == request.ItemId);

                Console.WriteLine ("its a new Lot");

                var addedAmount = request.NewQuantity - quantity;

                NewStockBatchDto newLot = new NewStockBatchDto () {
                    Quantity = addedAmount,
                    ItemId = request.ItemId,
                    AvailableFrom = DateTime.Now,
                    Status = "Recieved",
                    UnitCost = lastLot.UnitCost,
                    Source = "System Generated",
                    StorageLocation = new List<NewStockBatchStorageDto> () {
                    new NewStockBatchStorageDto () {
                    StorageId = item.DefaultStorageId,
                    Quantity = addedAmount
                    }
                    },

                };

                var result = await _Mediator.Send (newLot);

            }

            return Unit.Value;

        }
    }
}