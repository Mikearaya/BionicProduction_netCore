/*
 * @CreateTime: Nov 22, 2018 3:09 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 22, 2018 3:09 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.SalesOrders.Models {
    public class StatusUpdateDto {
        [Required]
        public string Status { get; set; }
    }
}