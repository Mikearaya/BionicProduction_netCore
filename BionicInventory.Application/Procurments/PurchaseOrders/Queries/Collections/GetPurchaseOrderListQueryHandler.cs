/*
 * @CreateTime: Jan 1, 2019 12:19 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 18, 2019 10:16 PM
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
    public class GetPurchaseOrderListQueryHandler : IRequestHandler<GetPurchaseOrderListQuery, IEnumerable<PurchaseOrderListView>> {
        private readonly IInventoryDatabaseService _database;

        public GetPurchaseOrderListQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<PurchaseOrderListView>> Handle (GetPurchaseOrderListQuery request, CancellationToken cancellationToken) {
            return await _database.PurchaseOrder
                .Include (p => p.PurchaseOrderQuotation)
                .Include (p => p.StockBatch)
                .Select (PurchaseOrderListView.Projection)
                .ToListAsync ();
        }
    }
}