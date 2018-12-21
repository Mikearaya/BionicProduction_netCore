/*
 * @CreateTime: Dec 2, 2018 6:35 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 2, 2018 7:40 PM
 * @Description: Deletes single product group
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Items;
using MediatR;

namespace BionicInventory.Application.Products.ProductGroups.Commands {
    public class DeleteProductGroupCommandHandler : IRequestHandler<DeleteProductGroupCommand> {
        private readonly IInventoryDatabaseService _database;

        public DeleteProductGroupCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }
        public async Task<Unit> Handle (DeleteProductGroupCommand request, CancellationToken cancellationToken) {
            var productGroup = await _database.ProductGroup.FindAsync (request.Id);

            if (productGroup == null) {
                throw new NotFoundException (nameof (ProductGroup), request.Id);
            }

            _database.ProductGroup.Remove (productGroup);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}