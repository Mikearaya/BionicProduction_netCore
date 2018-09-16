using System.Collections.Generic;
using BionicInventory.Application.Interfaces;
using BionicInventory.Application.Products.Models;
using BionicInventory.Domain.Items;

namespace BionicInventory.Application.Products.Interfaces {
    public interface IProductsCommand  {
        Item CreateProduct(Item newItem);
        bool UpdateProduct(Item product);

        bool DeleteProduct(Item deletedItem);
    }
}