
using System;

namespace BionicInventory.Application.SalesOrders.Models {

    public class CustomerOrderItemsView {

        private string _orderItemId = "";
        private string _manufacturingOrderId = "";
        public string id {get {
            return _orderItemId;
            } set {
                _orderItemId = $"COI-{value.ToString()}";  
            }
            }

        public int quantity {get; set;}
        public uint productId {get; set;}

        public string productCode {get; set;}
        public string productName {get; set;}
        public float unitPrice {get; set;}
        public double totalPrice {get; set;}

        public float unitCost {get; set;}

        public double totalCost {get; set;}
        public double profit {get; set;}
        public string status {get; set;}

        public DateTime deliveryDate {get; set;}
        public uint totalShipped {get; set;}

        public string manufacturingOrderId {get {
            return _manufacturingOrderId;
        } set{
            _manufacturingOrderId = $"MO-{value.ToString()}";
        }}

        public DateTime dateAdded {get; set;}
        public DateTime dateUpdated {get; set;}

        public DateTime dueDate {get; set;}



    }
}