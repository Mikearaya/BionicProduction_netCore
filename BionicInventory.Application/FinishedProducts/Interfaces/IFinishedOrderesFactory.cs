/*
 * @CreateTime: Sep 1, 2018 9:55 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 1, 2018 10:11 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.FinishedProducts.Models;
using BionicInventory.Domain.Employees;
using BionicInventory.Domain.FinishedProducts;
using BionicInventory.Domain.ProductionOrders;

namespace BionicInventory.Application.FinishedProducts.Interfaces {
    public interface IFinishedProductsFactories {

        FinishedProduct NewFinishedProduct(ProductionOrder order, Employee submited, Employee ordered, int quantity);
        FinishedProduct FinishedProductForUpdate(FinishedProduct current, FinishedProductDTO updated);

        FinishedProductsViewModel FinishedProductForView(FinishedProduct finishedProduct);

    }
}