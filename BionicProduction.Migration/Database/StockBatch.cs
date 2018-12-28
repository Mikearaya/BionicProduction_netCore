using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class StockBatch
    {
        public StockBatch()
        {
            BookedStockBatch = new HashSet<BookedStockBatch>();
            StockBatchStorage = new HashSet<StockBatchStorage>();
        }

        public uint Id { get; set; }
        public uint ItemId { get; set; }
        public float Quantity { get; set; }
        public float UnitCost { get; set; }
        public string Status { get; set; }
        public uint? PurchaseOrderId { get; set; }
        public uint? ManufactureOrderId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public Item Item { get; set; }
        public ProductionOrderList ManufactureOrder { get; set; }
        public ICollection<BookedStockBatch> BookedStockBatch { get; set; }
        public ICollection<StockBatchStorage> StockBatchStorage { get; set; }
    }
}
