using System.Collections.Generic;
using BionicInventory.Application.ProductionOrders.Iterfaces;
using BionicInventory.Domain.ProductionOrders;

namespace BionicInventory.Application.ProductionOrders.Queries {
    public class ProductionOrdersQuery : IProductionOrdersQuery {
        public IEnumerable<ProductionOrder> GetAll () {
            throw new System.NotImplementedException ();
        }

        public ProductionOrder GetById (uint id) {
            throw new System.NotImplementedException ();
        }
    }
}