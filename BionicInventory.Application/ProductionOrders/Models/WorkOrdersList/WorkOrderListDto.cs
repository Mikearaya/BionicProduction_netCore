/*
 * @CreateTime: Sep 19, 2018 10:43 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 19, 2018 10:43 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.ProductionOrders.Models.WorkOrdersList {
    public abstract class WorkOrderListDto {

        [Required]
        public uint ItemId { get; set; }

        [Required]
        public uint Quantity { get; set; }

        [Required]
        public float CostPerItem { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public bool? Complete { get; set; }
    }
}