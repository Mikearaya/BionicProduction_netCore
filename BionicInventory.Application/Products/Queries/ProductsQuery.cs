/*
 * @CreateTime: Sep 9, 2018 6:25 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 15, 2018 11:52 PM
 * @Description: Products Query Class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Products.Interfaces;
using BionicInventory.Application.Products.Models;
using BionicInventory.Domain.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Products.Queries {
    public class ProductsQuery : IProductsQuery {
        private readonly IInventoryDatabaseService _database;
        private readonly ILogger<ProductsQuery> _logger;

        public ProductsQuery (IInventoryDatabaseService database,
            ILogger<ProductsQuery> logger) {
            _database = database;
            _logger = logger;
        }
        public IEnumerable<Item> GetAllProduct () {

            try {

                return _database.Item.AsNoTracking ().ToList ();

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);
                return null;
            }
        }

        public bool IsProductCodeUnique (string code) {

            try {

                var result = _database.Item.Where (product => product.Code == code).FirstOrDefault ();
                return (result == null) ? true : false;

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);
                return false;
            }
        }

        public Item GetProductById (uint id) {

            try {

                return _database.Item.Find (id);

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);
                return null;
            }
        }

    }
}