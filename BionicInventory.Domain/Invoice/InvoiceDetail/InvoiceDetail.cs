using System;
using System.Collections.Generic;
using BionicInventory.Domain.FinishedProducts;
using BionicInventory.Domain.Sale;

namespace BionicInventory.Domain.Invoices.InvoiceDetails {
    public class InvoiceDetail {
        public InvoiceDetail () {
            Sale = new HashSet<Sales> ();
        }
        public uint Id { get; set; }
        public DateTime? DateAddded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint InventoryId { get; set; }
        public uint InvoiceNo { get; set; }
        public ICollection<Sales> Sale { get; set; }
        public FinishedProduct Inventory { get; set; }
        public Invoice InvoiceNoNavigation { get; set; }
    }
}