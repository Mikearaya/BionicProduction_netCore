using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database {
    public partial class UnitOfMeasurments {
        public UnitOfMeasurments () {
            BomItems = new HashSet<BomItems> ();
            ItemManufacturingUom = new HashSet<Item> ();
            ItemStoringUom = new HashSet<Item> ();
        }

        public uint Id { get; set; }
        public string Abrivation { get; set; }
        public string Name { get; set; }
        public sbyte? Active { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public ICollection<BomItems> BomItems { get; set; }
        public ICollection<Item> ItemManufacturingUom { get; set; }
        public ICollection<Item> ItemStoringUom { get; set; }
    }
}