﻿using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class Routing
    {
        public Routing()
        {
            RoutingDetail = new HashSet<RoutingDetail>();
        }

        public uint Id { get; set; }
        public uint BomId { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public float? FixedCost { get; set; }
        public float? VariableCost { get; set; }
        public uint? Quantity { get; set; }

        public Bom Bom { get; set; }
        public ICollection<RoutingDetail> RoutingDetail { get; set; }
    }
}