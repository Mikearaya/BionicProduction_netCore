/*
 * @CreateTime: Dec 2, 2018 1:15 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 2, 2018 1:22 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Products.ProductGroups.Interfaces;
using BionicInventory.Application.Products.ProductGroups.Models.Views;
using BionicInventory.Domain.Items;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Products.ProductGroups.Queries {
    public class ProductGroupQuery : IProductGroupQuery {
        private readonly ILogger<ProductGroupQuery> _logger;
        private readonly IInventoryDatabaseService _database;

        public ProductGroupQuery (IInventoryDatabaseService database,
            ILogger<ProductGroupQuery> logger) {
            _logger = logger;
            _database = database;
        }

        public IEnumerable<ProductGroup> GetAllProductGroups () {
            return _database.ProductGroup.ToList ();
        }

        public ProductGroup GetProductGroupById (uint id) {
            return _database.ProductGroup
                .Where (p => p.Id == id)
                .FirstOrDefault ();
        }

        public IEnumerable<ProductGroupView> GetProductGroupsView () {
            return _database.ProductGroup.Select (p => new ProductGroupView () {
                id = p.Id,
                    groupName = p.GroupName,
                    description = p.Description,
                    parentGroup = p.ParentGroupNavigation.GroupName,
                    parentGroupId = p.ParentGroup,
                    dateAdded = p.DateAdded,
                    dateUpdated = p.DateUpdated
            }).ToList ();
        }

        public ProductGroupView GetProductGroupViewById (uint id) {
            return _database.ProductGroup.Select (p => new ProductGroupView () {
                id = p.Id,
                    groupName = p.GroupName,
                    description = p.Description,
                    parentGroup = p.ParentGroupNavigation.GroupName,
                    parentGroupId = p.ParentGroup,
                    dateAdded = p.DateAdded,
                    dateUpdated = p.DateUpdated
            }).FirstOrDefault (p => p.id == id);
        }
    }
}