/*
 * @CreateTime: Sep 15, 2018 11:38 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 27, 2018 5:05 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Application.Customers.Models.Addresses;
using BionicInventory.Application.Customers.Models.PhoneNumbers;
using BionicInventory.Application.Customers.Models.SocialMedias;

namespace BionicInventory.Application.Customers.Models {
    public class CustomerViewModel {

        public CustomerViewModel () {
            addresses = new List<CustomerAddressView> ();
            socialMedias = new List<CustomerSocialMediaView> ();
            telephones = new List<CustomerPhoneView> ();
        }
        public uint id;
        public string fullName;
        public string tin;
        public string email;
        public string type;
        public int? paymentPeriod;
        public double? creditLimit;
        public string poBox;
        public DateTime? DateAdded;
        public DateTime? DateUpdated;

        public List<CustomerAddressView> addresses { get; set; }
        public List<CustomerSocialMediaView> socialMedias { get; set; }
        public List<CustomerPhoneView> telephones { get; set; }
    }
}