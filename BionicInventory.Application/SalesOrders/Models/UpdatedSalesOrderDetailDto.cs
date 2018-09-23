using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.SalesOrders.Models
{
    public class UpdatedSalesOrderDetailDto: SalesOrderDetailDto
    {
        [Required]
        public uint? Id { get; set; }
        [Required]
        public uint? PurchaseOrderId { get; set; }
    }
}