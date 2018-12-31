/*
 * @CreateTime: Jan 1, 2019 12:21 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 1, 2019 12:22 AM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Procurments.PurchaseOrders.Models;
using MediatR;

namespace BionicInventory.Application.Procurments.PurchaseOrders.Queries.Single {
    public class GetPurchaseOrderDetailQueryHandler : IRequestHandler<GetPurchaseOrderDetailQuery, PurchaseOrderDetailView> {
        private readonly IInventoryDatabaseService _database;

        public GetPurchaseOrderDetailQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public Task<PurchaseOrderDetailView> Handle (GetPurchaseOrderDetailQuery request, CancellationToken cancellationToken) {
            throw new System.NotImplementedException ();
        }
    }
}