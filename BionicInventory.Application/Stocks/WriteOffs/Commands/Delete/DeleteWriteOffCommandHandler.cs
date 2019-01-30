/*
 * @CreateTime: Jan 1, 2019 9:58 PM
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
    public class DeleteWriteOffCommandHandler : IRequestHandler<DeletedWriteOffDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public DeleteWriteOffCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeletedWriteOffDto request, CancellationToken cancellationToken) {
            var writeOff = await _database.WriteOff
                .Include (w => w.WriteOffDetail).FirstOrDefaultAsync (w => w.Id == request.Id);

            if (writeOff == null) {
                throw new NotFoundException (nameof (WriteOff), request.Id);
            }

            // add the writen off value back to storage lot location quantity
            foreach (var item in writeOff.WriteOffDetail) {
                var storage = await _database.StockBatchStorage.FindAsync (item.BatchStorageId);
                storage.Quantity += item.Quantity;
                _database.StockBatchStorage.Update (storage);
            }

            _database.WriteOff.Remove (writeOff);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}