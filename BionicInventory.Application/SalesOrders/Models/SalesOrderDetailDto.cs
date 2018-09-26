/*
 * @CreateTime: Sep 23, 2018 7:25 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 26, 2018 8:45 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.SalesOrders.Models {
    public class SalesOrderDetailDto {
        [Required]
        public uint ItemId { get; set; }
        [Required]
        public uint Quantity { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public float PricePerItem { get; set; }

    }
}