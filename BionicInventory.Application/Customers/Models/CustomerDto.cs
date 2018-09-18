using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.Customers.Models {
    public class CustomerDto {
        [Required]
        public string firstName { set; get; }

        [Required]
        public string lastName { set; get; }
        public string tin { set; get; }
        public string email { set; get; }

        [Required]
        public string type { set; get; }

        [Required]
        public string mainPhone { set; get; }
    }
}