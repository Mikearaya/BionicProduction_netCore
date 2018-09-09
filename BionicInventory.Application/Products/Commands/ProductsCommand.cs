/*
 * @CreateTime: Sep 9, 2018 5:57 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 9, 2018 6:59 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Products.Interfaces;
using BionicInventory.Application.Products.Models;
using BionicInventory.Domain.Items;
using Microsoft.EntityFrameworkCore;

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

        public Item CreateProduct (Item newItem) {

            try {

                _database.Item.Add (newItem);
                _database.Save ();

                return newItem;
            } catch (Exception) {
                return null;
            }
        }

        public bool DeleteProduct (Item deletedItem) {

            try {

                _database.Item.Remove (deletedItem);
                _database.Save ();

                return true;

            } catch (Exception) {
                return false;
            }
        }

        public ProductView DeleteProductPrices (ProductPriceDTO productPrice) {
            throw new System.NotImplementedException ();
        }

        public bool UpdateProduct (Item product) {
            try {

                _database.Item.Add (product).State = EntityState.Modified;
                _database.Save ();

                return true;

            } catch (Exception) {
                return false;
            }
        }

        public ProductView UpdateProductPrices (IEnumerable<ProductPriceDTO> productPrice) {
            throw new System.NotImplementedException ();
        }
    }
}