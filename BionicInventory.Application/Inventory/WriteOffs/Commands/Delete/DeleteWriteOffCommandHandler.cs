/*
 * @CreateTime: Jan 1, 2019 9:58 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 1, 2019 10:00 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Inventory.WriteOffs.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicProduction.Domain.WriteOffs;
using MediatR;

namespace BionicInventory.Application.Inventory.WriteOffs.Commands.Delete {
    public class DeleteWriteOffCommandHandler : IRequestHandler<DeletedWriteOffDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public DeleteWriteOffCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeletedWriteOffDto request, CancellationToken cancellationToken) {
            var writeOff = await _database.WriteOff.FindAsync (request.Id);

            if (writeOff == null) {
                throw new NotFoundException (nameof (WriteOff), request.Id);
            }

            _database.WriteOff.Remove (writeOff);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}