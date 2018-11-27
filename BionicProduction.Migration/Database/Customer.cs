using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class Customer
    {
        public Customer()
        {
            Address = new HashSet<Address>();
            PhoneNumber = new HashSet<PhoneNumber>();
            PurchaseOrder = new HashSet<PurchaseOrder>();
            SocialMedia = new HashSet<SocialMedia>();
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

        public ICollection<Address> Address { get; set; }
        public ICollection<PhoneNumber> PhoneNumber { get; set; }
        public ICollection<PurchaseOrder> PurchaseOrder { get; set; }
        public ICollection<SocialMedia> SocialMedia { get; set; }
    }
}
