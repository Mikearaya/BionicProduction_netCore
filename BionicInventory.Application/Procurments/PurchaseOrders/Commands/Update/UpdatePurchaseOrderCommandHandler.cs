/*
 * @CreateTime: Jan 1, 2019 12:15 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 1, 2019 12:17 AM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Procurments.PurchaseOrders.Models;
using MediatR;

namespace BionicInventory.Application.Procurments.PurchaseOrders.Commands.Update {
    public class UpdatePurchaseOrderCommandHandler : IRequestHandler<UpdatedPurchaseOrderDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public UpdatePurchaseOrderCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public Task<Unit> Handle (UpdatedPurchaseOrderDto request, CancellationToken cancellationToken) {
            throw new System.NotImplementedException ();
        }
    }
}