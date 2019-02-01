/*
 * @CreateTime: Jan 23, 2019 8:55 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 9:25 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Stocks.WriteOffs.Models;
using BionicProduction.Domain.WriteOffs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Stocks.WriteOffs.Commands.Delete {
    public class DeleteWriteOffDetailCommandHandler : IRequestHandler<DeleteWriteOffDetailDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public DeleteWriteOffDetailCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteWriteOffDetailDto request, CancellationToken cancellationToken) {
            var writeOff = await _database.WriteOffDetail.FindAsync (request.WriteOffDetailId);

            if (writeOff == null) {
                throw new NotFoundException (nameof (WriteOffDetail), request.WriteOffDetailId);
            }

            var storage = await _database.StockBatchStorage.
            Include (s => s.Batch)
                .FirstOrDefaultAsync (s => s.Id == writeOff.BatchStorageId);

            storage.Quantity += writeOff.Quantity;
            storage.Quantity += writeOff.Quantity;
            _database.StockBatchStorage.Update (storage);
            _database.WriteOffDetail.Remove (writeOff);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}