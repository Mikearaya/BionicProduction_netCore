/*
 * @CreateTime: Oct 2, 2018 8:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 16, 2018 11:13 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.BookedStockItem;
using BionicInventory.Domain.CustomerOrders;
using BionicInventory.Domain.FinishedProducts;
using BionicInventory.Domain.Invoices;
using BionicInventory.Domain.Invoices.InvoiceDetails;
using BionicInventory.Domain.Invoices.InvoicePayment;
using BionicInventory.Domain.ProductionOrders;
using BionicInventory.Domain.Shipments;

namespace BionicInventory.Domain.Employees {
    public class Employee {
        public Employee () {
            BookedStockItems = new HashSet<BookedStockItems> ();
            FinishedProductRecievedByNavigation = new HashSet<FinishedProduct> ();
            FinishedProductSubmittedByNavigation = new HashSet<FinishedProduct> ();
            Invoice = new HashSet<Invoice> ();
            InvoicePayments = new HashSet<InvoicePayments> ();
            ProductionOrderList = new HashSet<ProductionOrderList> ();
            CustomerOrder = new HashSet<CustomerOrder> ();
            Shipment = new HashSet<Shipment> ();
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
        public ICollection<CustomerOrder> CustomerOrder { get; set; }
        public ICollection<Shipment> Shipment { get; set; }

        public string FullName () {
            return FirstName + ' ' + LastName;
        }
    }
}