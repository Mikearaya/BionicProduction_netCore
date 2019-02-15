/*
 * @CreateTime: Sep 26, 2018 9:19 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 23, 2018 10:31 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.Customers;
using BionicInventory.Domain.Employees;
using BionicInventory.Domain.Invoices;
using BionicInventory.Domain.Shipments;
using BionicProduction.Domain.StockBatchs;

namespace BionicInventory.Domain.CustomerOrders {
    public partial class CustomerOrder {
        public CustomerOrder () {
            CustomerOrderItem = new HashSet<CustomerOrderItem> ();
            Invoice = new HashSet<Invoice> ();
            Shipment = new HashSet<Shipment> ();
        }

        public uint Id { get; set; }
        public uint ClientId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint CreatedBy { get; set; }
        public string Description { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? DueDate { get; set; }

        public Customer Client { get; set; }
        public Employee CreatedByNavigation { get; set; }
        public ICollection<CustomerOrderItem> CustomerOrderItem { get; set; }
        public ICollection<Invoice> Invoice { get; set; }
        public ICollection<Shipment> Shipment { get; set; }
    }
}