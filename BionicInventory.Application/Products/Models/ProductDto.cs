/*
 * @CreateTime: Oct 2, 2018 10:47 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 2, 2018 10:50 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.Products.Models {
    public abstract class ProductDto {
        private float _minimumQuantity = 0;

        [Required]
        public string code { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string unit { get; set; }

        public float MinimumQuantity {
            get { return _minimumQuantity; }
            set { _minimumQuantity = (value >= 0) ? value : 0; }
        }
        public string description { get; set; }

        [Required]
        public float weight { get; set; }

        [Required]
        public float unitCost { get; set; }

        [FileExtensions]
        public string photo { get; set; }

    }
}