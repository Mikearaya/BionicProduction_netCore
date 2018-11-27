/*
 * @CreateTime: Sep 15, 2018 11:40 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 27, 2018 8:52 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BionicInventory.Application.Customers.Models.Addresses;
using BionicInventory.Application.Customers.Models.PhoneNumbers;
using BionicInventory.Application.Customers.Models.SocialMedias;

namespace BionicInventory.Application.Customers.Models {
    public class NewCustomerDto : CustomerDto {

        public NewCustomerDto () {
            telephones = new List<CustomerPhoneDto> ();
            addresses = new List<CustomerAddressDto> ();
            socialMedias = new List<CustomerSocialMediaDto> ();
        }

        public List<CustomerPhoneDto> telephones { get; set; }
        public List<CustomerAddressDto> addresses { get; set; }
        public List<CustomerSocialMediaDto> socialMedias { get; set; }
    }
}