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
using BionicInventory.Domain.BookedStockItem;
using BionicInventory.Domain.Invoices.InvoiceDetails;
using BionicInventory.Domain.Items;
using BionicInventory.Domain.ProductionOrders;
using BionicInventory.Domain.Shipments.ShipmentDetails;
using BionicProduction.Domain.StockBatchs;

namespace BionicInventory.Domain.CustomerOrders {
    public class CustomerOrderItem {
        public CustomerOrderItem () {
            BookedStockBatch = new HashSet<BookedStockBatch> ();
            BookedStockItems = new HashSet<BookedStockItems> ();
            InvoiceDetail = new HashSet<InvoiceDetail> ();
            ShipmentDetail = new HashSet<ShipmentDetail> ();
        }

        public uint Id { get; set; }
        public uint CustomerOrderId { get; set; }
        public uint ItemId { get; set; }
        public uint Quantity { get; set; }
        public float PricePerItem { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime DueDate { get; set; }

        public CustomerOrder CustomerOrder { get; set; }
        public Item Item { get; set; }
        public ProductionOrderList ProductionOrderList { get; set; }
        public ICollection<BookedStockBatch> BookedStockBatch { get; set; }
        public ICollection<BookedStockItems> BookedStockItems { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetail { get; set; }
        public ICollection<ShipmentDetail> ShipmentDetail { get; set; }
    }
}