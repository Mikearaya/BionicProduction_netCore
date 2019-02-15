/*
 * @CreateTime: Feb 15, 2019 9:00 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 15, 2019 9:03 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Stocks.Shipments.Models;
using BionicInventory.Domain.Shipments;
using MediatR;

namespace BionicInventory.Application.Stocks.Shipments.Commands.Delete {
    public class DeleteShipmentCommandHandler : IRequestHandler<DeletedShipmentDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public DeleteShipmentCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeletedShipmentDto request, CancellationToken cancellationToken) {
            var shipment = await _database.Shipment
                .FindAsync (request.Id);

            if (shipment == null) {
                throw new NotFoundException (nameof (Shipment), request.Id);
            }

            _database.Shipment.Remove (shipment);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}