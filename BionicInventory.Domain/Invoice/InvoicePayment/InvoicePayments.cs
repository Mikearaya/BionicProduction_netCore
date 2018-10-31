using System;
using System.Collections.Generic;
using BionicInventory.Domain.Employees;

namespace BionicInventory.Domain.Invoices.InvoicePayment
{
    public class InvoicePayments
    {
        public uint Id { get; set; }
        public uint InvoiceNo { get; set; }
        public float Amount { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint PreparedBy { get; set; }
        public uint CashierId { get; set; }
        public int? PrintCount { get; set; }

        public Employee Cashier { get; set; }
        public Invoice InvoiceNoNavigation { get; set; }
        public Employee PreparedByNavigation { get; set; }
    }
}
