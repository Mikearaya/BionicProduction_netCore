﻿using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class StockBatch
    {
        public StockBatch()
        {
            StockBatchStorage = new HashSet<StockBatchStorage>();
        }

        public uint Id { get; set; }
        public uint ItemId { get; set; }
        public uint? ManufactureOrderId { get; set; }
        public uint? PurchaseOrderId { get; set; }
        public DateTime AvailableFrom { get; set; }
        public float Quantity { get; set; }
        public float UnitCost { get; set; }
        public string Status { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public string Source { get; set; }

        public virtual Item Item { get; set; }
        public virtual ProductionOrderList ManufactureOrder { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public virtual ICollection<StockBatchStorage> StockBatchStorage { get; set; }
    }
}
