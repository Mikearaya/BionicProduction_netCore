using System;
using System.Collections.Generic;

namespace BionicInventory.Domain.Invoices.InvoicePayment
{
    public class InvoicePayments
    {
        public uint Id { get; set; }
        public uint InvoiceNo { get; set; }
        public float Amount { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Invoice InvoiceNoNavigation { get; set; }
    }
}
