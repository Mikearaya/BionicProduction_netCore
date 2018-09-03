using System.Collections.Generic;
using BionicInventory.Application.FinishedProducts.Interfaces;
using BionicInventory.Domain.FinishedProducts;
using BionicInventory.Domain.ProductionOrders;

namespace BionicInventory.Application.FinishedProducts.Queries {
    public class FinishedProductsQuery : IFinishedProductsQuery
    {
        public IEnumerable<FinishedProduct> GetAllFinishedProducts()
        {
            throw new System.NotImplementedException();
        }

        public FinishedProduct GetFinishedProductById(uint id)
        {
            throw new System.NotImplementedException();
        }

        public FinishedProduct GetFinishedProductByOrder(ProductionOrder id)
        {
            throw new System.NotImplementedException();
        }
    }
}