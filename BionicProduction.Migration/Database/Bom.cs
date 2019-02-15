using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class Bom
    {
        public Bom()
        {
            BomItems = new HashSet<BomItems>();
            RoutingBoms = new HashSet<RoutingBoms>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public uint ItemId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public sbyte? Active { get; set; }

        public virtual Item Item { get; set; }
        public virtual ICollection<BomItems> BomItems { get; set; }
        public virtual ICollection<RoutingBoms> RoutingBoms { get; set; }
    }
}
