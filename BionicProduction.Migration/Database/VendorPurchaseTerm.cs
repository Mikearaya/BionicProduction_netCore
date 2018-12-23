using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class VendorPurchaseTerm
    {
        public uint Id { get; set; }
        public uint VendorId { get; set; }
        public uint ItemId { get; set; }
        public string VendorProductId { get; set; }
        public uint? Priority { get; set; }
        public uint? Leadtime { get; set; }
        public float? MinimumQuantity { get; set; }
        public float UnitPrice { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Item Item { get; set; }
        public Vendor Vendor { get; set; }
    }
}
