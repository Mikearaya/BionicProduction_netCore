using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class Vendor
    {
        public Vendor()
        {
            VendorPurchaseTerm = new HashSet<VendorPurchaseTerm>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string TinNumber { get; set; }
        public uint? LeadTime { get; set; }
        public uint? PaymentPeriod { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public ICollection<VendorPurchaseTerm> VendorPurchaseTerm { get; set; }
    }
}
