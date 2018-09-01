using System.Collections.Generic;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Products.Interfaces;
using BionicInventory.Application.Products.Models;
using BionicInventory.Domain.Items;

namespace BionicInventory.Application.Products.Queries {
    public class ProductsQuery : IProductsQuery {
        private readonly IInventoryDatabaseService _database;

        public ProductsQuery(IInventoryDatabaseService database) {
                _database = database;
            }
        public IEnumerable<Item> GetAllProduct()
        {
            return _database.Item.ToList();
        }

        public Item GetProductById(uint id)
        {
            return _database.Item.Find(id);
        }
    }
}