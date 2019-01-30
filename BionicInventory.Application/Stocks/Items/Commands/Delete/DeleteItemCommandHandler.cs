/*
 * @CreateTime: Jan 30, 2019 7:34 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 7:36 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Stocks.Items.Models;
using BionicInventory.Domain.Items;
using MediatR;

namespace BionicInventory.Application.Stocks.Items.Commands.Delete {
    public class DeleteItemCommandHandler : IRequestHandler<DeletedItemDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public DeleteItemCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeletedItemDto request, CancellationToken cancellationToken) {
            var item = await _database.Item.FindAsync (request.Id);

            if (item == null) {
                throw new NotFoundException (nameof (Item), request.Id);
            }

            _database.Item.Remove (item);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}