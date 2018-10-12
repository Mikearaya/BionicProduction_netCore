using System;

namespace BionicInventory.Application.SalesOrders.Models {
    public class CustomerOrdersView {

        private string _customerOrderId;
        public string Id { get{
            return _customerOrderId;
        } set{
            _customerOrderId = $"CO-{value.ToString()}";
        } }
        public string CustomerName { get; set; }
        public string CreatedBy { get; set; }
        public string Description { get; set; }
        public uint totalQuantity { get; set; }
        public uint totalProducts {get; set;}
        public float totalPrice { get; set; }
        public double totalCost { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public DateTime DateAdded{ get; set; }
        public DateTime DateUpdated { get; set; }
    }
}