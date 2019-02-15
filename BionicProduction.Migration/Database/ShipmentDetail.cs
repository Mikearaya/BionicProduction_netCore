using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class ShipmentDetail
    {
        public uint Id { get; set; }
        public uint ShipmentId { get; set; }
        public uint LotBookingId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public float? PickedQuantity { get; set; }
        public float BookedQuantity { get; set; }

        public virtual BookedStockBatch LotBooking { get; set; }
        public virtual Shipment Shipment { get; set; }
    }
}
