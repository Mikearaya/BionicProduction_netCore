/*
 * @CreateTime: Dec 4, 2018 10:41 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 4, 2018 10:41 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.Products.BOMs.Models {
    public class UpdatedBomItemDto {
        public uint? Id { get; set; }

        [Required]
        public uint ItemId { get; set; }
        public string Note { get; set; }

        [Required]
        public uint Quantity { get; set; }

        [Required]
        public uint UomId { get; set; }
    }
}