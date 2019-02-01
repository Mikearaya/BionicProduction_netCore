/*
 * @CreateTime: Jan 1, 2019 9:20 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 9:25 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Stocks.WriteOffs.Models;
using BionicInventory.Domain.Items;
using BionicProduction.Domain.StockBatchs;
using BionicProduction.Domain.WriteOffs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Stocks.WriteOffs.Commands.Create {
    public class CreateWriteOffCommandHandler : IRequestHandler<NewWriteOffDto, uint> {
        private readonly IInventoryDatabaseService _database;

        public CreateWriteOffCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<uint> Handle (NewWriteOffDto request, CancellationToken cancellationToken) {
            var item = await _database.Item.Where (i => i.Id == request.ItemId).CountAsync ();

            if (item == 0) {
                throw new NotFoundException (nameof (Item), request.ItemId);
            }

            if (request.WriteOffBatchs.Count () == 0) {
                throw new BelowRequiredMinimumItemException ("Batch", 1, "Write Off");
            }

            WriteOff newWriteOff = new WriteOff () {
                Status = "Valid",
                ItemId = request.ItemId,
                Type = request.Type,
                Note = request.Note
            };

            foreach (var data in request.WriteOffBatchs) {
                var batch = await _database.StockBatchStorage
                    .Include (s => s.Batch)
                    .Where (b => b.Id == data.BatchStorageId)
                    .FirstOrDefaultAsync ();

                if (batch == null) {
                    throw new NotFoundException (nameof (StockBatchStorage), data.BatchStorageId);
                } else if (batch.Quantity < data.Quantity) {
                    throw new QuantityGreaterThanAvailableException (
                        nameof (WriteOff),
                        data.Quantity,
                        batch.Quantity);
                }

                batch.Quantity = batch.Quantity - data.Quantity;
                batch.Batch.Quantity = batch.Batch.Quantity - data.Quantity;

                newWriteOff.WriteOffDetail.Add (new WriteOffDetail () {
                    BatchStorageId = data.BatchStorageId,
                        Quantity = data.Quantity,
                });
                // update storage
                _database.StockBatchStorage.Update (batch);

            }

            _database.WriteOff.Add (newWriteOff);

            await _database.SaveAsync ();

            return newWriteOff.Id;
        }
    }

}