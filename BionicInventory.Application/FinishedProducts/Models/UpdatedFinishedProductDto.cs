/*
 * @CreateTime: Sep 19, 2018 11:54 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 19, 2018 11:54 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.FinishedProducts.Models {
    public class UpdatedFinishedProductDto : FinishedProductDTO {

        [Required]
        public uint id { get; set; }
    }
}