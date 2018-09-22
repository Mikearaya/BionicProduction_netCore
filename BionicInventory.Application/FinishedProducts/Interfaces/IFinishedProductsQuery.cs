using System.Collections.Generic;
using BionicInventory.Application.FinishedProducts.Models;
using BionicInventory.Application.Interfaces;
using BionicInventory.Domain.FinishedProducts;
using BionicInventory.Domain.ProductionOrders;

namespace BionicInventory.Application.FinishedProducts.Interfaces {
    public interface IFinishedProductsQuery {
List<FinishedProductsViewModel> GetAllFinishedProducts ();
        FinishedProduct GetFinishedProductById (uint id);

        IEnumerable<FinishedProduct> GetFinishedProductByOrder (uint orderId);


    }
}