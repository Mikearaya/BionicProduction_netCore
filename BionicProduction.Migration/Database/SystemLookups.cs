using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class SystemLookups
    {
        public uint Id { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public sbyte? System { get; set; }
        public string Description { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
