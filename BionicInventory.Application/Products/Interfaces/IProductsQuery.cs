/*
 * @CreateTime: Sep 1, 2018 7:48 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 21, 2018 1:01 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Interfaces;
using BionicInventory.Application.Products.Models;
using BionicInventory.Domain.Items;

namespace BionicInventory.Application.Products.Interfaces {
    public interface IProductsQuery {
        Item GetProductById (uint id);
        bool IsProductCodeUnique (string code);
        IEnumerable<Item> GetAllProduct ();
        ProductView GetProductViewById (uint id);
        IEnumerable<CriticalStockItemsView> GetCriticalBelowStockItems ();
        CriticalStockItemsView GetCriticalBelowStockItem (uint id);

    }
}