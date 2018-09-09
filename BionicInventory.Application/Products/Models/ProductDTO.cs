/*
 * @CreateTime: Sep 9, 2018 6:14 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 9, 2018 6:14 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.Products.Models {
    public class ProductDTO {

        public uint id;

        [Required]
        public string code;
        [Required]
        public string name;

        [Required]

        public string unit;
        public string discription;
        [Required]
        public float weight;
        [Required]
        public float unitCost;
        public string photo;

    }
}