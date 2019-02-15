using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class SocialMedia
    {
        public uint Id { get; set; }
        public uint ClientId { get; set; }
        public string Address { get; set; }
        public string Site { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual Customer Client { get; set; }
    }
}
