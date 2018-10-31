/*
 * @CreateTime: Sep 26, 2018 9:19 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 2, 2018 8:35 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.Customers;
using BionicInventory.Domain.Employees;
using BionicInventory.Domain.Invoices;
using BionicInventory.Domain.PurchaseOrders.PurchaseOrderDetails;

namespace BionicInventory.Domain.PurchaseOrders {
    public class PurchaseOrder {
        public PurchaseOrder () {
            PurchaseOrderDetail = new HashSet<PurchaseOrderDetail> ();
        }

        public uint Id { get; set; }
        public uint ClientId { get; set; }
        public float InitialPayment { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint CreatedBy { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string OrderStatus { get; set; }

        public string PaymentMethod { get; set; }
        public DateTime? DueDate { get; set; }
        public Customer Client { get; set; }
        public Employee CreatedByNavigation { get; set; }
        public Invoice Invoice { get; set; }
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
    }
}