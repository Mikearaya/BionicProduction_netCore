/*
 * @CreateTime: Sep 19, 2018 10:43 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 26, 2018 1:31 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.ProductionOrders.Models.WorkOrdersList {
    public abstract class WorkOrderListDto {

        private uint _saleOrderId = 0;
        [Required]
        public uint ItemId { get; set; }

        [Required]
        public uint Quantity { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public uint? PurchaseOrderItemId {
            get {
                return _saleOrderId;
            }
            set {
                _saleOrderId = (value != 0) ? (uint) value : 0;
            }
        }

    }
}