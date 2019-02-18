using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class PurchaseOrderQuotation
    {
        public uint Id { get; set; }
        public uint PurchaseOrderId { get; set; }
        public float UnitPrice { get; set; }
        public float Quantity { get; set; }
        public DateTime ExpectedDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint ItemId { get; set; }

        public virtual Item Item { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
