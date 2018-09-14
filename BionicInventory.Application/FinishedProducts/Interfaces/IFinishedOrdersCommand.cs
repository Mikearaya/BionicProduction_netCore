
using BionicInventory.Application.Interfaces;
using BionicInventory.Domain.FinishedProducts;

namespace BionicInventory.Application.FinishedProducts.Interfaces {
    public interface IFinishedProductsCommand {

        FinishedProduct AddFinishedProduct(FinishedProduct finishedProduct);

        bool UpdateFinishedProduct(FinishedProduct current);

        bool DeleteFinishedProduct(FinishedProduct finishedProduct);

    }
}