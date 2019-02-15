using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class BookedStockBatch
    {
        public BookedStockBatch()
        {
            ShipmentDetail = new HashSet<ShipmentDetail>();
        }

        public uint Id { get; set; }
        public uint? BatchStorageId { get; set; }
        public uint? CustomerOrderId { get; set; }
        public uint? ProductionOrderId { get; set; }
        public float Quantity { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public float? ConsumedQuantity { get; set; }

        public virtual StockBatchStorage BatchStorage { get; set; }
        public virtual CustomerOrderItem CustomerOrder { get; set; }
        public virtual ProductionOrderList ProductionOrder { get; set; }
        public virtual ICollection<ShipmentDetail> ShipmentDetail { get; set; }
    }
}
