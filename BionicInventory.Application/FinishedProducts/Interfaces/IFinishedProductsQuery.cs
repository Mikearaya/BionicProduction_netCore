using System.Collections.Generic;
using BionicInventory.Application.Interfaces;
using BionicInventory.Domain.FinishedProducts;
using BionicInventory.Domain.ProductionOrders;

namespace BionicInventory.Application.FinishedProducts.Interfaces {
    public interface IFinishedProductsQuery {

        FinishedProduct GetFinishedProductById (uint id);

        FinishedProduct GetFinishedProductByOrder (ProductionOrder id);

        IEnumerable<FinishedProduct> GetAllFinishedProducts ();

    }
}