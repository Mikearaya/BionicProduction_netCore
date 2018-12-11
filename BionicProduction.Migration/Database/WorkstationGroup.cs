using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class WorkstationGroup
    {
        public WorkstationGroup()
        {
            Workstation = new HashSet<Workstation>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public sbyte? Active { get; set; }

        public ICollection<Workstation> Workstation { get; set; }
    }
}
