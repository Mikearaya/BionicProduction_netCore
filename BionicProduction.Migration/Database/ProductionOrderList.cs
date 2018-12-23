using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class ProductionOrderList
    {
        public ProductionOrderList()
        {
            BookedStockBatch = new HashSet<BookedStockBatch>();
            FinishedProduct = new HashSet<FinishedProduct>();
            StockBatch = new HashSet<StockBatch>();
        }

        public uint Id { get; set; }
        public uint ItemId { get; set; }
        public uint Quantity { get; set; }
        public float CostPerItem { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime DueDate { get; set; }
        public uint? PurchaseOrderId { get; set; }
        public DateTime Start { get; set; }
        public uint OrderedBy { get; set; }
        public string Description { get; set; }

        public Item Item { get; set; }
        public Employee OrderedByNavigation { get; set; }
        public PurchaseOrderDetail PurchaseOrder { get; set; }
        public ICollection<BookedStockBatch> BookedStockBatch { get; set; }
        public ICollection<FinishedProduct> FinishedProduct { get; set; }
        public ICollection<StockBatch> StockBatch { get; set; }
    }
}
