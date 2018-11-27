/*
 * @CreateTime: Sep 15, 2018 11:40 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 27, 2018 8:45 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BionicInventory.Application.Customers.Models.Addresses;
using BionicInventory.Application.Customers.Models.PhoneNumbers;
using BionicInventory.Application.Customers.Models.SocialMedias;

namespace BionicInventory.Application.Customers.Models {
    public class UpdatedCustomerDto : CustomerDto {

        [Required]
        public uint id { set; get; }
        public List<CustomerPhoneDto> telephones { get; set; } = new List<CustomerPhoneDto> ();
        public List<CustomerAddressDto> addresses { get; set; } = new List<CustomerAddressDto> ();
        public List<CustomerSocialMediaDto> socialMedias { get; set; } = new List<CustomerSocialMediaDto> ();
    }
}