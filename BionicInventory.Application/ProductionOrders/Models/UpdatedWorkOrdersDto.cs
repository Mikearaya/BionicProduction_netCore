using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.ProductionOrders.Models {
    public class UpdatedWorkOrderDto : WorkOrderDto {

        [Key]
        public uint Id { get; set; }


    }
}