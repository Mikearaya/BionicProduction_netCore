/*
 * @CreateTime: Feb 18, 2019 11:19 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 18, 2019 11:20 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Procurments.PurchaseOrders.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Procurments.PurchaseOrders.Queries.Collections {
    public class GetShippedPurchaseOrdersListQueryHandler : IRequestHandler<GetShippedPurchaseOrdersListQuery, IEnumerable<PurchaseOrderListView>> {
        private readonly IInventoryDatabaseService _database;

        public GetShippedPurchaseOrdersListQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<PurchaseOrderListView>> Handle (GetShippedPurchaseOrdersListQuery request, CancellationToken cancellationToken) {
            return await _database.PurchaseOrder
                .Where (p => p.Status.ToUpper () == "SHIPPED")
                .Include (p => p.PurchaseOrderQuotation)
                .Include (p => p.StockBatch)
                .Select (PurchaseOrderListView.Projection)
                .ToListAsync ();
        }
    }
}