using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class StorageLocation
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public sbyte? Active { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
