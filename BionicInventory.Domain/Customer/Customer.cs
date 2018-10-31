using System;
using System.Collections.Generic;
using BionicInventory.Domain.Customers.Addresses;
using BionicInventory.Domain.Customers.PhoneNumbers;
using BionicInventory.Domain.Customers.SocialMedias;
using BionicInventory.Domain.PurchaseOrders;

namespace BionicInventory.Domain.Customers {
    public class Customer {
        public Customer () {
            Address = new HashSet<Address> ();
            PhoneNumber = new HashSet<PhoneNumber> ();
            PurchaseOrder = new HashSet<PurchaseOrder> ();
        }

        public uint Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tin { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string MainPhone { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public SocialMedia SocialMedia { get; set; }
        public ICollection<Address> Address { get; set; }
        public ICollection<PhoneNumber> PhoneNumber { get; set; }
        public ICollection<PurchaseOrder> PurchaseOrder { get; set; }
        public string FullName() {
            return FirstName+' '+LastName;
        }
    }
}