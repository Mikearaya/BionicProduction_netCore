/*
 * @CreateTime: Nov 27, 2018 3:54 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 27, 2018 4:26 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.CustomerOrders;
using BionicInventory.Domain.Customers.Addresses;
using BionicInventory.Domain.Customers.PhoneNumbers;
using BionicInventory.Domain.Customers.SocialMedias;

namespace BionicInventory.Domain.Customers {
    public class Customer {
        public Customer () {
            Address = new HashSet<Address> ();
            PhoneNumber = new HashSet<PhoneNumber> ();
            CustomerOrder = new HashSet<CustomerOrder> ();
            SocialMedia = new HashSet<SocialMedia> ();
        }

        public uint Id { get; set; }
        public string FullName { get; set; }
        public string Tin { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public double? CreditLimit { get; set; }

        public int? PaymentPeriod { get; set; }
        public string Fax { get; set; }
        public string PoBox { get; set; }

        public ICollection<SocialMedia> SocialMedia { get; set; }
        public ICollection<Address> Address { get; set; }
        public ICollection<PhoneNumber> PhoneNumber { get; set; }
        public ICollection<CustomerOrder> CustomerOrder { get; set; }
    }
}