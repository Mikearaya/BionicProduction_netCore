/*
 * @CreateTime: Sep 23, 2018 7:19 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 23, 2018 7:29 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.SalesOrders.Models {
    public abstract class SalesOrderDto {
        [Required]
        public uint ClientId { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public float InitialPayment { get; set; }

    }
}