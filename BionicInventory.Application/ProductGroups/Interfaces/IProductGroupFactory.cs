/*
 * @CreateTime: Dec 2, 2018 12:58 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 2, 2018 5:22 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Products.ProductGroups.Models;
using BionicInventory.Domain.Items;

namespace BionicInventory.Application.Products.ProductGroups.Interfaces {
    public interface IProductGroupFactory {

        ProductGroup NewProductGroup (NewProductGroupDto newProduct);
        ProductGroup UpdatedProductGroup (ProductGroup group, UpdatedProductGroupDto newProduct);

    }
}