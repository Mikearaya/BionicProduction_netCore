/*
 * @CreateTime: Sep 1, 2018 7:48 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 1, 2018 8:31 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Interfaces;
using BionicInventory.Application.Products.Models;
using BionicInventory.Domain.Items;

namespace BionicInventory.Application.Products.Interfaces {
    public interface IProductsQuery {
        Item GetProductById (uint id);
        IEnumerable<Item> GetAllProduct ();

    }
}