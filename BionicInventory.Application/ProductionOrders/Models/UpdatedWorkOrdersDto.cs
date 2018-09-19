using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BionicInventory.Application.ProductionOrders.Models.WorkOrdersList;

namespace BionicInventory.Application.ProductionOrders.Models {
    public class UpdatedWorkOrderDto : WorkOrderDto {

        [Key]
        public uint Id { get; set; }

        [Required]
        public IEnumerable<UpdatedWorkOrdersListDto> workOrders { get; set; }

    }
}