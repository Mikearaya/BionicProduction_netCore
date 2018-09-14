using System;

namespace BionicInventory.Application.FinishedProducts.Models {
    public class FinishedProductsViewModel {
        public uint id;
        public uint orderId;
        public uint quantity;
        public uint submittedBy;
        public uint recievedBy;
        public DateTime dateAdded;
        public DateTime dateUpdated;
    }
}