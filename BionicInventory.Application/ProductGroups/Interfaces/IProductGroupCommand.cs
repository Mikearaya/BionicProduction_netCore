/*
 * @CreateTime: Dec 2, 2018 12:58 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 2, 2018 1:08 AM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.Items;

namespace BionicInventory.Application.Products.ProductGroups.Interfaces {
    public interface IProductGroupCommand {

        ProductGroup SaveProductGroup (ProductGroup newGroup);
        bool UpdateProductGroup (ProductGroup updatedGroup);
        bool DeleteProductGroup (ProductGroup deletedGroup);
    }
}