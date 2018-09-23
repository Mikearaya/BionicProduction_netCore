using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.SalesOrders.Models
{
    public class UpdatedSalesOrderDto: SalesOrderDto
    {
        [Required]
        public uint Id {get; set;}

        [Required]
        IEnumerable<UpdatedSalesOrderDetailDto> SalesDetail {get; set;}
    }
}