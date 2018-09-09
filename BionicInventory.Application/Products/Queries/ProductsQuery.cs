/*
 * @CreateTime: Sep 9, 2018 6:25 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 9, 2018 6:40 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Products.Interfaces;
using BionicInventory.Application.Products.Models;
using BionicInventory.Domain.Items;

namespace BionicInventory.Application.Products.Queries {
    public class ProductsQuery : IProductsQuery {
        private readonly IInventoryDatabaseService _database;

        public ProductsQuery (IInventoryDatabaseService database) {
            _database = database;
        }
        public IEnumerable<Item> GetAllProduct () {
            return _database.Item.ToList ();
        }

        public bool IsProductCodeUnique(string code)
        {
            var result = _database.Item.Where(product => product.Code == code).FirstOrDefault();

            return (result == null) ? true : false;
        }

        public Item GetProductById (uint id) {
            return _database.Item.Find (id);
        }

    }
}