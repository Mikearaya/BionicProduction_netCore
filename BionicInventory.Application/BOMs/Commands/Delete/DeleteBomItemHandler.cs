/*
 * @CreateTime: Dec 4, 2018 10:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 4, 2018 10:35 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Products.BOMs.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Items.BOMs;
using MediatR;

namespace BionicInventory.Application.Products.BOMs.Commands.Delete {
    public class DeleteBomItemHandler : IRequestHandler<DeletedBomItemDto, Unit> {

        private readonly IInventoryDatabaseService _database;

        public DeleteBomItemHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeletedBomItemDto request, CancellationToken cancellationToken) {
            var bomItem = await _database.BomItems.FindAsync (request.Id);

            if (bomItem == null) {
                throw new NotFoundException (nameof (BomItem), request.Id);
            };

            _database.BomItems.Remove (bomItem);

            await _database.SaveAsync ();

            return Unit.Value;
        }

        private object BomItem () {
            throw new NotImplementedException ();
        }
    }
}