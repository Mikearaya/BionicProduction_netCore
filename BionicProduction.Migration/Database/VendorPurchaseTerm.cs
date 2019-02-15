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
        public uint? LeadTime { get; set; }
        public uint? MinimumQuantity { get; set; }
        public float? UnitPrice { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual Item Item { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
