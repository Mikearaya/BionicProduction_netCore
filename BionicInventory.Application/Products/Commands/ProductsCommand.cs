using System.Collections.Generic;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Products.Interfaces;
using BionicInventory.Application.Products.Models;
using BionicInventory.Domain.Items;

namespace BionicInventory.Application.Products.Commands {
    public class ProductsCommand : IProductsCommand {
        private readonly IProductsFactory _factory;
        private readonly IInventoryDatabaseService _database;
        public ProductsCommand (IInventoryDatabaseService database, IProductsFactory factory) {
            _database = database;
            _factory = factory;

        }
        public ProductView AddProductPrices (Item product, IEnumerable<ProductPriceDTO> prices) {

            var productPrice = _factory.CreateProductPriceModel (product, prices);
            foreach (var price in productPrice) {
                _database.ItemPrice.Add (price);
            }
            _database.Save ();
            return _factory.CreateProductView (product);

        }

        public ProductView CreateProduct (ProductDTO newItem) {
            var product = _factory.CreateProductModel (newItem);

            _database.Item.Add (product);
            _database.Save ();

            return _factory.CreateProductView (product);
        }

        public bool DeleteProduct (Item deletedItem) {
            throw new System.NotImplementedException ();
        }

        public ProductView DeleteProductPrices (ProductPriceDTO productPrice) {
            throw new System.NotImplementedException ();
        }

        public bool UpdateProduct (Item product, ProductDTO updatedItem) {
            throw new System.NotImplementedException ();
        }

        public ProductView UpdateProductPrices (IEnumerable<ProductPriceDTO> productPrice) {
            throw new System.NotImplementedException ();
        }
    }
}