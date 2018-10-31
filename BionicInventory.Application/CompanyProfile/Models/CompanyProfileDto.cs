/*
 * @CreateTime: Oct 16, 2018 11:26 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 16, 2018 11:26 PM
 * @Description: Modify Here, Please 
 */

using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.CompanyProfile.Models {
    public abstract class CompanyProfileDto {
        
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string Tin { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string SubCity { get; set; }
        public string Location { get; set; }
    }
}
