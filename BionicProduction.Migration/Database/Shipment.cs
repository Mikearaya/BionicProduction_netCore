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
        public uint BookedBy { get; set; }
        public string ShipmentNote { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateAdded { get; set; }
        public uint CustomerOrderId { get; set; }
        public string Status { get; set; }

        public Employee BookedByNavigation { get; set; }
        public PurchaseOrder CustomerOrder { get; set; }
        public ICollection<ShipmentDetail> ShipmentDetail { get; set; }
    }
}