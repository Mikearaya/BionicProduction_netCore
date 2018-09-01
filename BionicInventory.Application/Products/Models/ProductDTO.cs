using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.Products.Models {
    public class ProductDTO {

        [Required]
        public string code;
        [Required]
        public string name;
        public string discription;
        [Required]
        public float weight;
        [Required]
        public float unitCost;
        public string photo;

    }
}