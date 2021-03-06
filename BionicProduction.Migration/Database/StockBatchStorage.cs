﻿using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class StockBatchStorage
    {
        public StockBatchStorage()
        {
            BookedStockBatch = new HashSet<BookedStockBatch>();
            InversePreviousStorage = new HashSet<StockBatchStorage>();
            WriteOffDetail = new HashSet<WriteOffDetail>();
        }

        public uint Id { get; set; }
        public uint BatchId { get; set; }
        public uint StorageId { get; set; }
        public uint? PreviousStorageId { get; set; }
        public float Quantity { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual StockBatch Batch { get; set; }
        public virtual StockBatchStorage PreviousStorage { get; set; }
        public virtual StorageLocation Storage { get; set; }
        public virtual ICollection<BookedStockBatch> BookedStockBatch { get; set; }
        public virtual ICollection<StockBatchStorage> InversePreviousStorage { get; set; }
        public virtual ICollection<WriteOffDetail> WriteOffDetail { get; set; }
    }
}
