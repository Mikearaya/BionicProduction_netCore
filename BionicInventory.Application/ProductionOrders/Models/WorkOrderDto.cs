using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.ProductionOrders.Models {
    public abstract class WorkOrderDto {
        [Required]
        public string Description { get; set; }

        [Required]
        public uint OrderedBy { get; set; }

    }
}