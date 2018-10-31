using System;
using System.Collections.Generic;

namespace BionicInventory.Domain.Customers.PhoneNumbers
{
    public class PhoneNumber
    {
        public uint Id { get; set; }
        public uint ClientId { get; set; }
        public string Number { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Customer Client { get; set; }
    }
}
