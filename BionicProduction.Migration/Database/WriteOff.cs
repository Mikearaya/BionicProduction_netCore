using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class WriteOff
    {
        public WriteOff()
        {
            WriteOffDetail = new HashSet<WriteOffDetail>();
        }

        public uint Id { get; set; }
        public uint ItemId { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public string Type { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual Item Item { get; set; }
        public virtual ICollection<WriteOffDetail> WriteOffDetail { get; set; }
    }
}
