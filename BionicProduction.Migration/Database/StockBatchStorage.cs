using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class StockBatchStorage
    {
        public StockBatchStorage()
        {
            BookedStockBatch = new HashSet<BookedStockBatch>();
            InversePreviousStorageNavigation = new HashSet<StockBatchStorage>();
            WriteOffDetail = new HashSet<WriteOffDetail>();
        }

        public uint Id { get; set; }
        public uint BatchId { get; set; }
        public uint StorageId { get; set; }
        public uint? PreviousStorage { get; set; }
        public float Quantity { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public StockBatch Batch { get; set; }
        public StockBatchStorage PreviousStorageNavigation { get; set; }
        public StorageLocation Storage { get; set; }
        public ICollection<BookedStockBatch> BookedStockBatch { get; set; }
        public ICollection<StockBatchStorage> InversePreviousStorageNavigation { get; set; }
        public ICollection<WriteOffDetail> WriteOffDetail { get; set; }
    }
}
