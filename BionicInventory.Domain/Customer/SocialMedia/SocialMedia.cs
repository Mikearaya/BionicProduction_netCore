using System;
using System.Collections.Generic;

namespace BionicInventory.Domain.Customers.SocialMedias
{
    public class SocialMedia
    {
        public uint Id { get; set; }
        public uint ClientId { get; set; }
        public string Address { get; set; }
        public string Site { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Customer Client { get; set; }
    }
}
