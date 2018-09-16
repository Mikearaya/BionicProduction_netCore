/*
 * @CreateTime: Sep 9, 2018 5:57 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 16, 2018 12:00 AM
 * @Description: Products Command Class
 */
using System;
using System.Collections.Generic;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Products.Interfaces;
using BionicInventory.Application.Products.Models;
using BionicInventory.Domain.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Products.Commands {
    public class ProductsCommand : IProductsCommand {

        
        private readonly IProductsFactory _factory;
        private readonly IInventoryDatabaseService _database;
        private readonly ILogger<ProductsCommand> _logger;

        public ProductsCommand (IInventoryDatabaseService database,
                                IProductsFactory factory,
                                ILogger<ProductsCommand> logger) {
            _database = database;
            _factory = factory;
            _logger = logger;

        }

        public Item CreateProduct (Item newItem) {

            try {

                _database.Item.Add (newItem);
                _database.Save ();

                return newItem;

            } catch (Exception e) {
                _logger.LogError(1, e.Message, e);
                return null;
            }
        }

        public bool DeleteProduct (Item deletedItem) {

            try {

                _database.Item.Remove (deletedItem);
                _database.Save ();

                return true;

            } catch (Exception e) {
                _logger.LogError(1, e.Message, e);
                return false;
            }
        }


        public bool UpdateProduct (Item product) {
            try {

                _database.Item.Add (product).State = EntityState.Modified;
                _database.Save ();

                return true;

            } catch (Exception e) {
                _logger.LogError(1, e.Message, e);
                return false;
            }
        }

   
    }
}