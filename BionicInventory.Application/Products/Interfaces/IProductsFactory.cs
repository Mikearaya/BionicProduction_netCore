/*
 * @CreateTime: Sep 1, 2018 7:48 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 1, 2018 8:16 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Products.Models;
using BionicInventory.Domain.Items;
using BionicInventory.Domain.Items.ItemPrices;

namespace BionicInventory.Application.Products.Interfaces {
    public interface IProductsFactory {
        Item CreateProductModel (ProductDTO newProduct);
        ProductView CreateProductView (Item product);
        IEnumerable<ItemPrice> CreateProductPriceModel (Item product, IEnumerable<ProductPriceDTO> prices);

    }
}