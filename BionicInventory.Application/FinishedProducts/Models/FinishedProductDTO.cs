/*
 * @CreateTime: Sep 14, 2018 10:16 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 14, 2018 11:05 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.FinishedProducts.Models {
    public abstract class FinishedProductDTO {

        [Required]
        public uint orderId { get; set; }

        [Required]
        public int quantity { get; set; }

        [Required]
        public uint recievedBy { get; set; }

        [Required]
        public uint submittedBy { get; set; }

    }
}