/*
 * @CreateTime: Jan 1, 2019 12:14 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 10, 2019 10:26 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Procurments.PurchaseOrders.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Procurment.PurchaseOrders;
using MediatR;

namespace BionicInventory.Application.Procurments.PurchaseOrders.Commands.Delete {
    public class DeletePurchaseOrderCommandHandler : IRequestHandler<DeletedPurchaseOrderDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public DeletePurchaseOrderCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeletedPurchaseOrderDto request, CancellationToken cancellationToken) {
            var purchaseOrder = await _database
                .PurchaseOrder
                .FindAsync (request.Id);

            if (purchaseOrder == null) {
                throw new NotFoundException (nameof (PurchaseOrder), request.Id);
            }

            _database.PurchaseOrder.Remove (purchaseOrder);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}