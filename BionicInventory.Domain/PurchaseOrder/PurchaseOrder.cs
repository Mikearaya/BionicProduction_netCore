using System;
using System.Collections.Generic;
using BionicInventory.Domain.Customers;
using BionicInventory.Domain.Employees;
using BionicInventory.Domain.Invoices;
using BionicInventory.Domain.PurchaseOrders.PurchaseOrderDetails;

namespace BionicInventory.Domain.PurchaseOrders {
    public class PurchaseOrder {
        public PurchaseOrder () {
            PurchaseOrderDetail = new List<PurchaseOrderDetail> ();
        }

        public uint Id { get; set; }
        public uint ClientId { get; set; }
        public DateTime IssuedOn { get; set; }
        public float InitialPayment { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint CreatedBy { get; set; }

        public string PaymentMethod { get; set; }

        public Customer Client { get; set; }
        public Employee CreatedByNavigation { get; set; }
        public Invoice Invoice { get; set; }
        public List<PurchaseOrderDetail> PurchaseOrderDetail { get; set; } = new List<PurchaseOrderDetail> ();
    }
}