/*
 * @CreateTime: Oct 16, 2018 11:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 16, 2018 11:28 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.CompanyProfile.Models {
    public class UpdatedCompanyProfileDto: CompanyProfileDto {
        [Key]
        [Required]
        public uint Id { get; set; }
    }
}