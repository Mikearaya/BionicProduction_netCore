using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class BomItems
    {
        public uint Id { get; set; }
        public uint ItemId { get; set; }
        public string Note { get; set; }
        public uint Quantity { get; set; }
        public uint UomId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint BomId { get; set; }

        public Bom Bom { get; set; }
        public Item Item { get; set; }
        public UnitOfMeasurment Uom { get; set; }
    }
}
