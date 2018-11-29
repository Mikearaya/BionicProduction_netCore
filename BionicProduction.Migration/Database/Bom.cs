using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class Bom
    {
        public Bom()
        {
            InverseItem = new HashSet<Bom>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public uint ItemId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Bom Item { get; set; }
        public ICollection<Bom> InverseItem { get; set; }
    }
}
