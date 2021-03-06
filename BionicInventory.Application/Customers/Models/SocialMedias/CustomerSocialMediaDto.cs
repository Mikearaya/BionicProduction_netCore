/*
 * @CreateTime: Nov 27, 2018 3:15 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 27, 2018 8:51 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.Customers.Models.SocialMedias {
    public class CustomerSocialMediaDto {
        public uint? Id { get; set; } = 0;

        [Required]
        public string site { get; set; }

        [Required]
        public string address { get; set; }
    }
}