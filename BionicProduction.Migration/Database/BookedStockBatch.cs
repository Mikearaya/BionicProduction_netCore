using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class BookedStockBatch
    {
        public uint Id { get; set; }
        public uint? BatchStorageId { get; set; }
        public uint? ProductionOrderId { get; set; }
        public uint? CustomerOrderId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public float Quantity { get; set; }

        public StockBatchStorage BatchStorage { get; set; }
        public CustomerOrderItem CustomerOrder { get; set; }
        public ProductionOrderList ProductionOrder { get; set; }
    }
}
