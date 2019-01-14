using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class PurchaseOrderItem
    {
        public PurchaseOrderItem()
        {
            StockBatch = new HashSet<StockBatch>();
        }

        public uint Id { get; set; }
        public uint PurchaseOrderId { get; set; }
        public uint ItemId { get; set; }
        public float Quantity { get; set; }
        public float UnitPrice { get; set; }
        public DateTime ExpectedDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Item Item { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        public ICollection<StockBatch> StockBatch { get; set; }
    }
}
