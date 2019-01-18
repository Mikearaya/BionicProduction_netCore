using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class ShipmentDetail
    {
        public uint Id { get; set; }
        public uint ShipmentId { get; set; }
        public uint StockId { get; set; }
        public uint OrderItemId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public sbyte? Picked { get; set; }

        public CustomerOrderItem OrderItem { get; set; }
        public Shipment Shipment { get; set; }
        public FinishedProduct Stock { get; set; }
    }
}
