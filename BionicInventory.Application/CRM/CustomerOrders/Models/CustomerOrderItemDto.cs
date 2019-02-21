/*
 * @CreateTime: Feb 21, 2019 8:43 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 21, 2019 8:46 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.CRM.CustomerOrders.Models {
    public class CustomerOrderItemDto {
        [Required]
        public uint? Id { get; set; }

        [Required]
        public uint ItemId { get; set; }

        [Required]
        public uint Quantity { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public float UnitPrice { get; set; }
    }
}