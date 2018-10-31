using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.ProductionOrders.Models {
    public abstract class WorkOrderDto {

        private uint _saleOrderId = 0;
        public string Description { get; set; }

        [Required]
        public uint OrderedBy { get; set; }
        [Required]
        public uint ItemId { get; set; }

        [Required]
        public uint Quantity { get; set; }

        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public DateTime Start { get; set; }

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