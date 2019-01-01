/*
 * @CreateTime: Jan 1, 2019 9:52 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 1, 2019 9:56 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Inventory.WriteOffs.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicProduction.Domain.WriteOffs;
using MediatR;

namespace BionicInventory.Application.Inventory.WriteOffs.Commands.Update {
    public class UpdateWriteOffCommandHandler : IRequestHandler<UpdatedWriteOffDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public UpdateWriteOffCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (UpdatedWriteOffDto request, CancellationToken cancellationToken) {
            var writeOff = await _database.WriteOff.FindAsync (request.Id);

            if (writeOff == null) {
                throw new NotFoundException (nameof (WriteOff), request.Id);
            }

            writeOff.Status = request.Status;
            writeOff.Type = request.Type;
            writeOff.Note = request.Note;
            _database.WriteOff.Update (writeOff);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}