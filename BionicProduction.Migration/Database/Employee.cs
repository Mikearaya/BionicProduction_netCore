using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class Employee
    {
        public Employee()
        {
            BookedStockItems = new HashSet<BookedStockItems>();
            FinishedProductRecievedByNavigation = new HashSet<FinishedProduct>();
            FinishedProductSubmittedByNavigation = new HashSet<FinishedProduct>();
            Invoice = new HashSet<Invoice>();
            InvoicePayments = new HashSet<InvoicePayments>();
            ProductionOrderList = new HashSet<ProductionOrderList>();
            PurchaseOrder = new HashSet<PurchaseOrder>();
            Shipment = new HashSet<Shipment>();
        }

        public uint Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public ICollection<BookedStockItems> BookedStockItems { get; set; }
        public ICollection<FinishedProduct> FinishedProductRecievedByNavigation { get; set; }
        public ICollection<FinishedProduct> FinishedProductSubmittedByNavigation { get; set; }
        public ICollection<Invoice> Invoice { get; set; }
        public ICollection<InvoicePayments> InvoicePayments { get; set; }
        public ICollection<ProductionOrderList> ProductionOrderList { get; set; }
        public ICollection<PurchaseOrder> PurchaseOrder { get; set; }
        public ICollection<Shipment> Shipment { get; set; }
    }
}
