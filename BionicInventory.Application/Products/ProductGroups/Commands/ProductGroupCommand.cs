/*
 * @CreateTime: Dec 2, 2018 1:14 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 2, 2018 1:14 AM
 * @Description: Modify Here, Please 
 */
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Products.ProductGroups.Interfaces;
using BionicInventory.Domain.Items;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Products.ProductGroups.Commands {
    public class ProductGroupCommand : IProductGroupCommand {
        private readonly IInventoryDatabaseService _database;
        private readonly ILogger<ProductGroupCommand> _logger;

        public ProductGroupCommand (IInventoryDatabaseService database,
            ILogger<ProductGroupCommand> logger) {
            _database = database;
            _logger = logger;
        }
        public bool DeleteProductGroup (ProductGroup deletedGroup) {
            _database.ProductGroup.Remove (deletedGroup);
            _database.Save ();
            return true;
        }

        public ProductGroup SaveProductGroup (ProductGroup newGroup) {
            _database.ProductGroup.Add (newGroup);
            _database.Save ();
            return newGroup;
        }

        public bool UpdateProductGroup (ProductGroup updatedGroup) {
            _database.ProductGroup.Update (updatedGroup);
            _database.Save ();
            return true;
        }
    }
}