using System;

namespace BionicInventory.Application.Customers.Models {
    public class CustomerViewModel {
        public uint ID;
        public string FullName;
        public string Tin;
        public string email;
        public string type;
        public string mainPhone;
        public DateTime? DateAdded;
        public DateTime? DateUpdated;
    }
}