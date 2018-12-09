using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class UnitOfMeasurment
    {
        public UnitOfMeasurment()
        {
            BomItems = new HashSet<BomItems>();
            Item = new HashSet<Item>();
        }

        public uint Id { get; set; }
        public string Abrivation { get; set; }
        public string Name { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public sbyte? Active { get; set; }

        public ICollection<BomItems> BomItems { get; set; }
        public ICollection<Item> Item { get; set; }
    }
}
