/*
 * @CreateTime: Jan 1, 2019 9:52 PM
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
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Stocks.WriteOffs.Models;
using BionicProduction.Domain.StockBatchs;
using BionicProduction.Domain.WriteOffs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Stocks.WriteOffs.Commands.Update {
    public class UpdateWriteOffCommandHandler : IRequestHandler<UpdatedWriteOffDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public UpdateWriteOffCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (UpdatedWriteOffDto request, CancellationToken cancellationToken) {
            var writeOff = await _database.WriteOff
                .Include (w => w.WriteOffDetail)
                .FirstOrDefaultAsync (w => w.Id == request.Id);

            if (writeOff == null) {
                throw new NotFoundException (nameof (WriteOff), request.Id);
            }

            writeOff.Status = request.Status;
            writeOff.Type = request.Type;
            writeOff.Note = request.Note;

            foreach (var data in request.WriteOffBatchs) {
                var batch = await _database.StockBatchStorage
                    .Include (b => b.WriteOffDetail)
                    .AsNoTracking ()
                    .Where (b => b.Id == data.BatchStorageId)
                    .FirstOrDefaultAsync ();

                if (batch == null) {
                    throw new NotFoundException (nameof (StockBatchStorage), data.BatchStorageId);

                    // check if there is available stock 
                } else if (batch.Quantity < data.Quantity) {
                    throw new QuantityGreaterThanAvailableException (
                        nameof (WriteOff),
                        data.Quantity,
                        batch.Quantity);
                }

                writeOff.WriteOffDetail.Add (new WriteOffDetail () {
                    WriteOffId = request.Id,
                        BatchStorageId = data.BatchStorageId,
                        Quantity = data.Quantity,
                });
            }

            _database.WriteOff.Update (writeOff);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}