using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceDetail = new HashSet<InvoiceDetail>();
            InvoicePayments = new HashSet<InvoicePayments>();
        }

        public uint Id { get; set; }
        public uint PurchaseOrderId { get; set; }
        public string InvoiceType { get; set; }
        public byte? PrintCount { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public float? Tax { get; set; }
        public float? Discount { get; set; }
        public string Note { get; set; }
        public DateTime? DueDate { get; set; }
        public uint PreparedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string PaymentMethod { get; set; }

        public virtual Employee PreparedByNavigation { get; set; }
        public virtual CustomerOrder PurchaseOrder { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetail { get; set; }
        public virtual ICollection<InvoicePayments> InvoicePayments { get; set; }
    }
}
