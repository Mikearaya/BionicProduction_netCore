/*
 * @CreateTime: Oct 1, 2018 11:20 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 1, 2018 11:20 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.SalesOrders.Models {
    public class SalesOrderView {
        public uint Id { get; set; }
        public string CustomerName { get; set; }
        public string OrderCode { get; set; }
        public string CreatedBy { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public uint Quantity { get; set; }
        public float UnitPrice { get; set; }
        public double remainingPayment { get; set; }
        public float paidAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public double totalPrice { get; set; }
        public DateTime OrderedOn { get; set; }
        public DateTime DueDate { get; set; }
    }
}