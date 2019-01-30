/*
 * @CreateTime: Jan 9, 2019 7:41 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 8:38 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Storages;
using BionicProduction.Domain.StockBatchs;
using MediatR;

namespace BionicInventory.Application.Stocks.StockLots.Commands.Create {
    public class MoveStockLotCommandHandler : IRequestHandler<StockLotMovementDto, uint> {
        private readonly IInventoryDatabaseService _database;

        public MoveStockLotCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<uint> Handle (StockLotMovementDto request, CancellationToken cancellationToken) {
            var mainLotStorage = await _database.StockBatchStorage.FindAsync (request.LotId);

            // check if current stock lot exsists
            if (mainLotStorage == null) {
                throw new NotFoundException (nameof (StockBatch), request.LotId);
            }

            // check if there is sufficient amount in current stock lot
            if (mainLotStorage.Quantity < request.Quantity) {
                throw new QuantityGreaterThanAvailableException ("Lot", request.Quantity, mainLotStorage.Quantity);
            }

            if (mainLotStorage.StorageId == request.newStorageId) {
                throw new DuplicateStorageLocationMovementException (mainLotStorage.Id, mainLotStorage.Storage.Name);
            }

            var newLot = await _database.StorageLocation.FindAsync (request.newStorageId);

            // check if new storage location exists
            if (newLot == null) {
                throw new NotFoundException (nameof (StorageLocation), request.newStorageId);
            }

            mainLotStorage.Quantity = mainLotStorage.Quantity - request.Quantity;

            _database.StockBatchStorage.Update (mainLotStorage);

            _database.StockBatchStorage.Add (new StockBatchStorage () {
                StorageId = request.newStorageId,
                    Quantity = request.Quantity,
                    BatchId = mainLotStorage.BatchId,
                    PreviousStorageId = mainLotStorage.PreviousStorageId
            });

            await _database.SaveAsync ();

            return mainLotStorage.BatchId;
        }
    }
}