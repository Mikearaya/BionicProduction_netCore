using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class Employee
    {
        public Employee()
        {
            BookedStockItems = new HashSet<BookedStockItems>();
            CustomerOrder = new HashSet<CustomerOrder>();
            FinishedProductRecievedByNavigation = new HashSet<FinishedProduct>();
            FinishedProductSubmittedByNavigation = new HashSet<FinishedProduct>();
            Invoice = new HashSet<Invoice>();
            InvoicePayments = new HashSet<InvoicePayments>();
            ProductionOrderList = new HashSet<ProductionOrderList>();
        }

        public uint Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual ICollection<BookedStockItems> BookedStockItems { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrder { get; set; }
        public virtual ICollection<FinishedProduct> FinishedProductRecievedByNavigation { get; set; }
        public virtual ICollection<FinishedProduct> FinishedProductSubmittedByNavigation { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<InvoicePayments> InvoicePayments { get; set; }
        public virtual ICollection<ProductionOrderList> ProductionOrderList { get; set; }
    }
}
