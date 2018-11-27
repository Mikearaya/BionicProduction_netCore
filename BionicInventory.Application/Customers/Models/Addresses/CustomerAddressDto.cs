/*
 * @CreateTime: Nov 27, 2018 3:07 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 27, 2018 4:08 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.Customers.Models.Addresses {
    public class CustomerAddressDto {

        public uint? Id { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string SubCity { get; set; }

        [Required]
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
    }
}