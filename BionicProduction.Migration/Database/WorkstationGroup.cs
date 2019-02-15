using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class WorkstationGroup
    {
        public WorkstationGroup()
        {
            RoutingOperation = new HashSet<RoutingOperation>();
            Workstation = new HashSet<Workstation>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public sbyte? Active { get; set; }

        public virtual ICollection<RoutingOperation> RoutingOperation { get; set; }
        public virtual ICollection<Workstation> Workstation { get; set; }
    }
}
