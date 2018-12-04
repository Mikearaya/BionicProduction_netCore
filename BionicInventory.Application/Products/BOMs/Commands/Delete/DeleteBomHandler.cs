/*
 * @CreateTime: Dec 4, 2018 10:30 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 5, 2018 12:17 AM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Products.BOMs.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Items.BOMs;
using MediatR;

namespace BionicInventory.Application.Products.BOMs.Commands.Delete {
    public class DeleteBomHandler : IRequestHandler<DeletedBomDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public DeleteBomHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeletedBomDto request, CancellationToken cancellationToken) {
            var bom = await _database.Bom.FindAsync (request.Id);

            if (bom == null) {
                throw new NotFoundException (nameof (Bom), request.Id);
            };

            _database.Bom.Remove (bom);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}