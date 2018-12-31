/*
 * @CreateTime: Jan 1, 2019 12:12 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 1, 2019 12:13 AM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Procurments.PurchaseOrders.Models;
using MediatR;

namespace BionicInventory.Application.Procurments.PurchaseOrders.Commands.Create {
    public class CreatePurchaseOrderCommandHandler : IRequestHandler<NewPurchaseOrderDto, PurchaseOrderDetailView> {
        private readonly IInventoryDatabaseService _database;

        public CreatePurchaseOrderCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public Task<PurchaseOrderDetailView> Handle (NewPurchaseOrderDto request, CancellationToken cancellationToken) {
            throw new System.NotImplementedException ();
        }
    }
}