using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            PurchaseOrderQuotation = new HashSet<PurchaseOrderQuotation>();
            StockBatch = new HashSet<StockBatch>();
        }

        public uint Id { get; set; }
        public uint VendorId { get; set; }
        public string Status { get; set; }
        public DateTime ExpectedDate { get; set; }
        public DateTime? OrderedDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public float? Tax { get; set; }
        public float? AdditionalFee { get; set; }
        public float? Discount { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string OrderId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string InvoiceId { get; set; }
        public DateTime? InvoiceDate { get; set; }

        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<PurchaseOrderQuotation> PurchaseOrderQuotation { get; set; }
        public virtual ICollection<StockBatch> StockBatch { get; set; }
    }
}
