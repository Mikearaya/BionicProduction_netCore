using System;
using System.Collections.Generic;
using BionicInventory.Domain.Invoices.InvoiceDetails;
using BionicInventory.Domain.Invoices.InvoicePayment;
using BionicInventory.Domain.PurchaseOrders;

namespace BionicInventory.Domain.Invoices
{
    public class Invoice
    {
        public Invoice()
        {
            InvoiceDetail = new HashSet<InvoiceDetail>();
            InvoicePayments = new HashSet<InvoicePayments>();
        }

        public uint Id { get; set; }
        public uint PurchaseOrderId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public double Amount { get; set; }

        public PurchaseOrder PurchaseOrder { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetail { get; set; }
        public ICollection<InvoicePayments> InvoicePayments { get; set; }
    }
}
