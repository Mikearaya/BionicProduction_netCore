/*
 * @CreateTime: Sep 23, 2018 7:19 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 4, 2018 9:32 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.SalesOrders.Models {
    public abstract class SalesOrderDto {

        [Required]
        public string Status { get; set; }
        [Required]
        public uint ClientId { get; set; }

        [Required]
        public uint CreatedBy { get; set; }

        [MaxLength (255)]
        public string Description { get; set; }

        public DateTime? CreatedOn { get; set; }

    }
}