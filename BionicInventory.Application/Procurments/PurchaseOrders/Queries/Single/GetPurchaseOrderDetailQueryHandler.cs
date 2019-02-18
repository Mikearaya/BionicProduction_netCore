/*
 * @CreateTime: Jan 1, 2019 12:21 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 18, 2019 10:16 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Procurments.PurchaseOrders.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Procurments.PurchaseOrders.Queries.Single {
    public class GetPurchaseOrderDetailQueryHandler : IRequestHandler<GetPurchaseOrderDetailQuery, PurchaseOrderDetailView> {
        private readonly IInventoryDatabaseService _database;

        public GetPurchaseOrderDetailQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public Task<PurchaseOrderDetailView> Handle (GetPurchaseOrderDetailQuery request, CancellationToken cancellationToken) {
            return _database.PurchaseOrder
                .Include (p => p.PurchaseOrderQuotation)
                .Include (p => p.StockBatch)
                .Where (po => po.Id == request.Id)
                .Select (PurchaseOrderDetailView.Projection)
                .FirstOrDefaultAsync ();
        }
    }
}