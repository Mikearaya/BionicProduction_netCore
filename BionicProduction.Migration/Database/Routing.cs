using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class Routing
    {
        public Routing()
        {
            RoutingBoms = new HashSet<RoutingBoms>();
            RoutingOperation = new HashSet<RoutingOperation>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public float? FixedCost { get; set; }
        public float? VariableCost { get; set; }
        public uint? Quantity { get; set; }
        public uint ItemId { get; set; }

        public virtual Item Item { get; set; }
        public virtual ICollection<RoutingBoms> RoutingBoms { get; set; }
        public virtual ICollection<RoutingOperation> RoutingOperation { get; set; }
    }
}
