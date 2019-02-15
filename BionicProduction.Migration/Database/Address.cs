using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class Address
    {
        public uint Id { get; set; }
        public uint ClientId { get; set; }
        public string SubCity { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }

        public virtual Customer Client { get; set; }
    }
}
