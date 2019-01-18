/*
 * @CreateTime: Sep 1, 2018 9:55 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 21, 2018 10:26 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.FinishedProducts.Models;
using BionicInventory.Domain.Employees;
using BionicInventory.Domain.FinishedProducts;
using BionicInventory.Domain.ProductionOrders;

namespace BionicInventory.Application.FinishedProducts.Interfaces {
    public interface IFinishedProductsFactories {

        FinishedProduct NewFinishedProduct (ProductionOrderList order, Employee submited, Employee ordered, int quantity);
        FinishedProduct FinishedProductForUpdate (UpdatedFinishedProductDto updated);

        FinishedProductsViewModel FinishedProductForView (FinishedProduct finishedProduct);

        List<FinishedProductsViewModel> FinishedProductForView (List<FinishedProduct> finishedProduct);

    }
}