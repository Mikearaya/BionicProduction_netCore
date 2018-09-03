using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.FinishedProducts.Models
{
    public class FinishedProductDTO
    {
        [Required]
        public uint orderId;
        [Required]
        public int quantity;
        [Required]
        public uint recievedBy;
        [Required]
        public uint submittedBy;
        
    }
}