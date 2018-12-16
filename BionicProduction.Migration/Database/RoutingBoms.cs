using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class RoutingBoms
    {
        public uint Id { get; set; }
        public uint RoutingId { get; set; }
        public uint BomId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Bom Bom { get; set; }
        public Routing Routing { get; set; }
    }
}
