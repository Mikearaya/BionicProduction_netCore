/*
 * @CreateTime: Nov 8, 2018 11:55 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 14, 2018 11:33 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.Employees;
using BionicInventory.Domain.PurchaseOrders.PurchaseOrderDetails;

namespace BionicInventory.Domain.Invoices.InvoiceDetails {
    public class InvoiceDetail {

        public uint Id { get; set; }
        public DateTime? DateAddded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public float? Discount { get; set; }
        public uint SalesOrderId { get; set; }
        public uint InvoiceNo { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
        public float UnitPrice { get; set; }
        public float? Tax { get; set; }

        public Invoice InvoiceNoNavigation { get; set; }
        public PurchaseOrderDetail SalesOrder { get; set; }
    }
}