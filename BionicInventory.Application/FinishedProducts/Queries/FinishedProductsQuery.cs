using System.Collections.Generic;
using BionicInventory.Application.FinishedProducts.Interfaces;
using BionicInventory.Domain.FinishedProducts;

namespace BionicInventory.Application.FinishedProducts.Queries {
    public class FinishedProductsQuery : IFinishedProductsQuery {
        public IEnumerable<FinishedProduct> GetAll () {
            throw new System.NotImplementedException ();
        }

        public FinishedProduct GetById (uint id) {
            throw new System.NotImplementedException ();
        }
    }
}