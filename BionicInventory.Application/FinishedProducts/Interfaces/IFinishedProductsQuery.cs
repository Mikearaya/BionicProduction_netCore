/*
 * @CreateTime: Sep 30, 2018 5:42 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 30, 2018 5:42 PM
 * @Description: Modify Here, Please 
 */
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

        IEnumerable<StockStatusView> GetStockReport(); 


    }
}