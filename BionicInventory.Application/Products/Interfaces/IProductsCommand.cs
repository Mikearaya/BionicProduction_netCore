using System.Collections.Generic;
using BionicInventory.Application.Interfaces;
using BionicInventory.Application.Products.Models;
using BionicInventory.Domain.Items;

namespace BionicInventory.Application.Products.Interfaces {
    public interface IProductsCommand  {
        ProductView CreateProduct(ProductDTO newItem);

        ProductView AddProductPrices(Item product, IEnumerable<ProductPriceDTO> productPrice);
        ProductView UpdateProductPrices(IEnumerable<ProductPriceDTO> productPrice);
        ProductView DeleteProductPrices(ProductPriceDTO productPrice);
        bool UpdateProduct(Item product, ProductDTO updatedItem);

        bool DeleteProduct(Item deletedItem);
    }
}