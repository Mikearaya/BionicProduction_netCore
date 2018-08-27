using System;
using System.Collections.Generic;
using BionicInventory.Domain.FinishedProducts;

namespace BionicInventory.Domain.Invoices.InvoiceDetails
{
    public class InvoiceDetail
    {
        public uint Id { get; set; }
        public DateTime? DateAddded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint InventoryId { get; set; }
        public uint InvoiceNo { get; set; }

        public FinishedProduct Inventory { get; set; }
        public Invoice InvoiceNoNavigation { get; set; }
    }
}
