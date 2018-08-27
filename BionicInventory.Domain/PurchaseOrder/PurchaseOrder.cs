using System;
using System.Collections.Generic;
using BionicInventory.Domain.Customers;
using BionicInventory.Domain.Invoices;
using BionicInventory.Domain.PurchaseOrders.PurchaseOrderDetails;

namespace BionicInventory.Domain.PurchaseOrders
{
    public class PurchaseOrder
    {
        public PurchaseOrder()
        {
            PurchaseOrderDetail = new HashSet<PurchaseOrderDetail>();
        }

        public uint Id { get; set; }
        public uint ClientId { get; set; }
        public DateTime IssuedOn { get; set; }
        public DateTime DueDate { get; set; }
        public float InitialPayment { get; set; }
        public float PaymentAmount { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public float? AddedPayment { get; set; }

        public Customer Client { get; set; }
        public Invoice Invoice { get; set; }
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
    }
}
