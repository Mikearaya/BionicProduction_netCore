using System;

namespace BionicInventory.Domain.Companies {
    public class Company {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Tin { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string SubCity { get; set; }
        public string Location { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}