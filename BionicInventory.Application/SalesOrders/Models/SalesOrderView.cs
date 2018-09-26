using System;

namespace BionicInventory.Application.SalesOrders.Models {
    public class SalesOrderView {
        public uint Id { get; set; }
        public string CustomerName { get; set; }
        public string OrderCode { get; set; }
        public string CreatedBy { get; set; }
        public string ItemCode { get; set; }
        public uint Quantity { get; set; }
        public float UnitPrice { get; set; }

        public double remainingPayment {get; set;}
        public float paidAmount {get; set;}
        public double totalAmount {get; set;}
        public DateTime OrderedOn { get; set; }
        public DateTime DueDate { get; set; }
    }
}