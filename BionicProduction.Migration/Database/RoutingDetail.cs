using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class RoutingDetail
    {
        public uint Id { get; set; }
        public uint RoutingId { get; set; }
        public uint WorkstationId { get; set; }
        public string Operation { get; set; }
        public double? FixedCost { get; set; }
        public double? VariableCost { get; set; }
        public float? FixedTime { get; set; }
        public float? VariableTime { get; set; }
        public uint? WorkerId { get; set; }
        public int Quantity { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Routing Routing { get; set; }
        public Employee Worker { get; set; }
        public Workstation Workstation { get; set; }
    }
}
