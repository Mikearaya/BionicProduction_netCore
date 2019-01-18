using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class CustomerOrderItem
    {
        public CustomerOrderItem()
        {
            BookedStockBatch = new HashSet<BookedStockBatch>();
            BookedStockItems = new HashSet<BookedStockItems>();
            InvoiceDetail = new HashSet<InvoiceDetail>();
            ShipmentDetail = new HashSet<ShipmentDetail>();
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
