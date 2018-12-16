/*
 * @CreateTime: Dec 17, 2018 12:11 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 17, 2018 12:14 AM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Items.Rotings;
using MediatR;

namespace BionicInventory.Application.Routings.Commands.Delete {
    public class DeleteRoutingCommandHandler : IRequestHandler<DeletedRoutingDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public DeleteRoutingCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeletedRoutingDto request, CancellationToken cancellationToken) {
            var routing = await _database.Routing.FindAsync (request.Id);

            if (routing == null) {
                throw new NotFoundException (nameof (Routing), request.Id);
            }

            _database.Routing.Remove (routing);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}