using BionicInventory.Application.FinishedProducts.Interfaces;
using BionicInventory.Application.FinishedProducts.Models;
using BionicInventory.Domain.Employees;
using BionicInventory.Domain.FinishedProducts;
using BionicInventory.Domain.ProductionOrders;

namespace BionicInventory.Application.FinishedProducts.Factories
{
    public class FinishedProductsFactory : IFinishedProductsFactories
    {

        public FinishedProduct NewFinishedProduct(ProductionOrder order, Employee submited, Employee recieved, int quantity)
        {
            var finishedProduct = new FinishedProduct();
            finishedProduct.OrderId = order.Id;
            finishedProduct.SubmittedBy = submited.Id;
            finishedProduct.RecievedBy = recieved.Id;
            finishedProduct.Quantity = quantity;

            return finishedProduct;
        }

        public FinishedProduct FinishedProductForUpdate(FinishedProduct current, FinishedProductDTO updated )
        {
            current.OrderId = updated.orderId;
            current.SubmittedBy = updated.submittedBy;
            current.RecievedBy = updated.recievedBy;
            current.Quantity = updated.quantity;
            return current;
        }

        public FinishedProductsViewModel FinishedProductForView(FinishedProduct finishedProduct)
        {
            throw new System.NotImplementedException();
        }

    }
}