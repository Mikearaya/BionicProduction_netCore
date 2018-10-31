using System;

namespace BionicInventory.Application.SalesOrders.Models {
    public class CustomerOrdersView {

       // private string _customerOrderId;
        public uint id { get; set; }
        public string customerName { get; set; }
        public string createdBy { get; set; }
        public string description { get; set; }
        public uint totalQuantity { get; set; }
        public uint totalProducts {get; set;}
        public float totalPrice { get; set; }
        public double totalCost { get; set; }
        public string paymentMethod { get; set; }
        public string status { get; set; }
        public DateTime dueDate {get; set;}
        public DateTime dateAdded{ get; set; }
        public DateTime dateUpdated { get; set; }
    }
}