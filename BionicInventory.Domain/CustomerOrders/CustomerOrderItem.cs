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
using BionicProduction.Domain.StockBatchs;

namespace BionicInventory.Domain.CustomerOrders {
    public partial class CustomerOrderItem {
        public CustomerOrderItem () {
            BookedStockBatch = new HashSet<BookedStockBatch> ();
            BookedStockItems = new HashSet<BookedStockItems> ();
            InvoiceDetail = new HashSet<InvoiceDetail> ();
        }

        public uint Id { get; set; }
        public uint CustomerOrderId { get; set; }
        public uint ItemId { get; set; }
        public uint Quantity { get; set; }
        public float PricePerItem { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime DueDate { get; set; }

        public virtual CustomerOrder CustomerOrder { get; set; }
        public virtual Item Item { get; set; }
        public virtual ICollection<BookedStockBatch> BookedStockBatch { get; set; }
        public virtual ICollection<BookedStockItems> BookedStockItems { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetail { get; set; }
    }
}