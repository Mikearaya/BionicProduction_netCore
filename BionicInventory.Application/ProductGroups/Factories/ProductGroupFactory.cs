/*
 * @CreateTime: Dec 2, 2018 1:25 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 2, 2018 5:38 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Products.ProductGroups.Interfaces;
using BionicInventory.Application.Products.ProductGroups.Models;
using BionicInventory.Domain.Items;

namespace BionicInventory.Application.Products.ProductGroups.Factories {
    public class ProductGroupFactory : IProductGroupFactory {
        public ProductGroup NewProductGroup (NewProductGroupDto newProduct) {
            ProductGroup group = new ProductGroup () {
                GroupName = newProduct.GroupName,

            };

            if (newProduct.ParentGroup != 0) {
                group.ParentGroup = newProduct.ParentGroup;
            }
            if (newProduct.Description != "") {
                group.Description = newProduct.Description;
            }

            return group;

        }

        public ProductGroup UpdatedProductGroup (ProductGroup oldGroup, UpdatedProductGroupDto newProduct) {

            if (newProduct.ParentGroup != 0) {
                oldGroup.ParentGroup = newProduct.ParentGroup;
            }
            
            oldGroup.GroupName = newProduct.GroupName;
            oldGroup.ParentGroup = newProduct.ParentGroup;

            // update description if only the value has changed
            if (oldGroup.Description == null && newProduct.Description != "" || oldGroup.Description != null && newProduct.Description == "" ||
                newProduct.Description.ToLower () != oldGroup.Description.ToLower ()) {
                oldGroup.Description = newProduct.Description;
            }

            return oldGroup;

        }
    }
}