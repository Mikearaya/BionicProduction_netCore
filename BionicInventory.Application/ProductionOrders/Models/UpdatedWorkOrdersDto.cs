using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BionicInventory.Application.ProductionOrders.Models.WorkOrdersList;

namespace BionicInventory.Application.ProductionOrders.Models {
    public class UpdatedWorkOrderDto {

        [Key]
        public uint Id;
        [Required]
        public string Description;
        [Required]
        public uint OrderedBy;
        [Required]
        public ICollection<UpdatedWorkOrdersListDto> workOrderItems { get; set; }
    }
}