using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.ProductionOrders.Models {
    public class UpdatedWorkOrderDto {

        [Key]
        public uint Id;
        [Required]
        public string Description;
        [Required]
        public uint OrderedBy;

        public IList<NewWorkOrderDto> ProdutionOrdersList;
    }
}