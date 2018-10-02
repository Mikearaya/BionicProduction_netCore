/*
 * @CreateTime: Sep 26, 2018 9:19 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 2, 2018 8:31 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.Invoices.InvoiceDetails;
using BionicInventory.Domain.Items;
using BionicInventory.Domain.ProductionOrders.ProductionOrderLists;

namespace BionicInventory.Domain.PurchaseOrders.PurchaseOrderDetails {
    public class PurchaseOrderDetail {
        public PurchaseOrderDetail()
        {
            InvoiceDetail = new HashSet<InvoiceDetail>();
        }

        public uint Id { get; set; }
        public uint PurchaseOrderId { get; set; }
        public uint ItemId { get; set; }
        public uint Quantity { get; set; }
        public float PricePerItem { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime DueDate { get; set; }

        public Item Item { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        public ProductionOrderList ProductionOrderList { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetail { get; set; }
    }
}