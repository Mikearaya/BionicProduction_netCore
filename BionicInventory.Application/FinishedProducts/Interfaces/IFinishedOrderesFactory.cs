/*
 * @CreateTime: Sep 1, 2018 9:55 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 20, 2018 12:00 AM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.FinishedProducts.Models;
using BionicInventory.Domain.Employees;
using BionicInventory.Domain.FinishedProducts;
using BionicInventory.Domain.ProductionOrders.ProductionOrderLists;

namespace BionicInventory.Application.FinishedProducts.Interfaces {
    public interface IFinishedProductsFactories {

        FinishedProduct NewFinishedProduct(ProductionOrderList order, Employee submited, Employee ordered, int quantity);
        FinishedProduct FinishedProductForUpdate(UpdatedFinishedProductDto updated);

        FinishedProductsViewModel FinishedProductForView(FinishedProduct finishedProduct);

    }
}