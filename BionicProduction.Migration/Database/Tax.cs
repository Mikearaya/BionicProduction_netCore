using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class Tax
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Abrevation { get; set; }
        public float Percentage { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
