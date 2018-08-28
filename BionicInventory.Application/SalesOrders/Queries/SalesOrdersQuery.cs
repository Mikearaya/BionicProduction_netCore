using System.Collections.Generic;
using BionicInventory.Application.SalesOrders.Interfaces;
using BionicInventory.Domain.PurchaseOrders;

namespace BionicInventory.Application.SalesOrders.Queries {
    public class SalesOrdersQuery : ISalesOrdersQuery {
        public IEnumerable<PurchaseOrder> GetAll () {
            throw new System.NotImplementedException ();
        }

        public PurchaseOrder GetById (uint id) {
            throw new System.NotImplementedException ();
        }
    }
}