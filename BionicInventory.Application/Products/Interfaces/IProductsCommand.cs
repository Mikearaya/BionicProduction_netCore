using System.Collections.Generic;
using BionicInventory.Application.Interfaces;
using BionicInventory.Application.Products.Models;
using BionicInventory.Domain.Items;

namespace BionicInventory.Application.Products.Interfaces {
    public interface IProductsCommand  {
        Item CreateProduct(Item newItem);

        ProductView AddProductPrices(Item product, IEnumerable<ProductPriceDTO> productPrice);
        ProductView UpdateProductPrices(IEnumerable<ProductPriceDTO> productPrice);
        ProductView DeleteProductPrices(ProductPriceDTO productPrice);
        bool UpdateProduct(Item product);

        bool DeleteProduct(Item deletedItem);
    }
}