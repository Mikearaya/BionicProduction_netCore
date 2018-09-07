using System;

namespace BionicInventory.Application.Customers.Models {
    public class CustomerViewModel {
        public uint id;
        public string firstName;
        public string lastName;
        public string tin;
        public string email;
        public string type;
        public string mainPhone;
        public DateTime? DateAdded;
        public DateTime? DateUpdated;
    }
}