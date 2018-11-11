using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class UnitOfMeasures
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Abrevation { get; set; }
        public string Symbole { get; set; }
        public float Conversion { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
