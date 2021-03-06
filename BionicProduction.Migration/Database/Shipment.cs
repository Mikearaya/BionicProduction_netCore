﻿using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class Shipment
    {
        public Shipment()
        {
            ShipmentDetail = new HashSet<ShipmentDetail>();
        }

        public uint Id { get; set; }
        public uint? BookedBy { get; set; }
        public string ShipmentNote { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryAddress { get; set; }
        public string WaybillNote { get; set; }
        public string PickingListNote { get; set; }
        public string Status { get; set; }

        public virtual ICollection<ShipmentDetail> ShipmentDetail { get; set; }
    }
}
