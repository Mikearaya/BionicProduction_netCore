using System;
using System.Collections.Generic;
using BionicInventory.Domain.FinishedProducts;
using BionicInventory.Domain.Invoices.InvoicePayment;
using BionicInventory.Domain.ProductionOrders;
using BionicInventory.Domain.PurchaseOrders;
using BionicInventory.Domain.Sale;

namespace BionicInventory.Domain.Employees
{
    public class Employee
    {
         public Employee()
        {
            FinishedProductRecievedByNavigation = new HashSet<FinishedProduct>();
            FinishedProductSubmittedByNavigation = new HashSet<FinishedProduct>();
            InvoicePaymentsCashier = new HashSet<InvoicePayments>();
            InvoicePaymentsPreparedByNavigation = new HashSet<InvoicePayments>();
            ProductionOrder = new HashSet<ProductionOrder>();
            PurchaseOrder = new HashSet<PurchaseOrder>();
            Sales = new HashSet<Sales>();
        }

        public uint Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public ICollection<FinishedProduct> FinishedProductRecievedByNavigation { get; set; }
        public ICollection<FinishedProduct> FinishedProductSubmittedByNavigation { get; set; }
        public ICollection<InvoicePayments> InvoicePaymentsCashier { get; set; }
        public ICollection<InvoicePayments> InvoicePaymentsPreparedByNavigation { get; set; }
        public ICollection<ProductionOrder> ProductionOrder { get; set; }
        public ICollection<PurchaseOrder> PurchaseOrder { get; set; }
        public ICollection<Sales> Sales { get; set; }

        public string FullName() {
            return FirstName+' '+LastName;
        }
    }
}
