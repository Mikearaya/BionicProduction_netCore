/*
 * @CreateTime: Jan 1, 2019 12:19 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 1, 2019 12:21 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Procurments.PurchaseOrders.Models;
using MediatR;

namespace BionicInventory.Application.Procurments.PurchaseOrders.Queries.Collections {
    public class GetPurchaseOrderListQueryHandler : IRequestHandler<GetPurchaseOrderListQuery, IEnumerable<PurchaseOrderListView>> {
        private readonly IInventoryDatabaseService _database;

        public GetPurchaseOrderListQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public Task<IEnumerable<PurchaseOrderListView>> Handle (GetPurchaseOrderListQuery request, CancellationToken cancellationToken) {
            throw new System.NotImplementedException ();
        }
    }
}