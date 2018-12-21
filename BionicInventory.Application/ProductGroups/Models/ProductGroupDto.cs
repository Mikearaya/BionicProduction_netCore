/*
 * @CreateTime: Dec 2, 2018 1:01 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 2, 2018 1:02 AM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.Products.ProductGroups.Models {
    public abstract class ProductGroupDto {
        [Required]
        public string GroupName { get; set; }
        public string Description { get; set; }
        public uint? ParentGroup { get; set; }

    }
}