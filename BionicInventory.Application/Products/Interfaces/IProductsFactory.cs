/*
 * @CreateTime: Sep 1, 2018 7:48 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 15, 2018 11:53 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Products.Models;
using BionicInventory.Domain.Items;
using BionicInventory.Domain.Items.ItemPrices;

namespace BionicInventory.Application.Products.Interfaces {
    public interface IProductsFactory {
        Item CreateProductModel (NewProductDto newProduct);

        Item ProductUpdateModel (Item product, UpdatedProductDto updatedProduct);
        ProductView CreateProductView (Item product);

    }
}