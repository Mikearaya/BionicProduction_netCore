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
        public byte? PrintCount { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public PurchaseOrder PurchaseOrder { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetail { get; set; }
        public ICollection<InvoicePayments> InvoicePayments { get; set; }
    }
}
