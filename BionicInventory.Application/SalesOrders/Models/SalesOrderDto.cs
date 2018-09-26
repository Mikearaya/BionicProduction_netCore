/*
 * @CreateTime: Sep 23, 2018 7:19 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 26, 2018 8:45 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.SalesOrders.Models {
    public abstract class SalesOrderDto {
        
        public uint Id { get; set; }
        [Required]
        public uint ClientId { get; set; }
        [Required]
        public string PaymentMethod {get; set;}
        [Required]
        public float InitialPayment { get; set; }
        [Required]
        public uint CreatedBy { get; set; }

    }
}