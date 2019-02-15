using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class PhoneNumber
    {
        public uint Id { get; set; }
        public uint ClientId { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual Customer Client { get; set; }
    }
}
