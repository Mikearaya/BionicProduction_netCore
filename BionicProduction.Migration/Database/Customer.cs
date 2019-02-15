using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class Customer
    {
        public Customer()
        {
            Address = new HashSet<Address>();
            CustomerOrder = new HashSet<CustomerOrder>();
            PhoneNumber = new HashSet<PhoneNumber>();
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

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrder { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumber { get; set; }
        public virtual ICollection<SocialMedia> SocialMedia { get; set; }
    }
}
