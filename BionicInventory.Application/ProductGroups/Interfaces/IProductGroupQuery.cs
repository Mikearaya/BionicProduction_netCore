/*
 * @CreateTime: Dec 2, 2018 12:59 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 2, 2018 1:15 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Products.ProductGroups.Models.Views;
using BionicInventory.Domain.Items;

namespace BionicInventory.Application.Products.ProductGroups.Interfaces {

    public interface IProductGroupQuery {

        ProductGroup GetProductGroupById (uint id);
        IEnumerable<ProductGroup> GetAllProductGroups ();

        IEnumerable<ProductGroupView> GetProductGroupsView ();
        ProductGroupView GetProductGroupViewById (uint id);

    }
}