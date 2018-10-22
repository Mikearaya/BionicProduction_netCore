using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class PurchaseOrderDetail
    {
        public PurchaseOrderDetail()
        {
            BookedStockItems = new HashSet<BookedStockItems>();
            InvoiceDetail = new HashSet<InvoiceDetail>();
            ProductionOrderList = new HashSet<ProductionOrderList>();
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
        public ICollection<BookedStockItems> BookedStockItems { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetail { get; set; }
        public ICollection<ProductionOrderList> ProductionOrderList { get; set; }
    }
}
