/*
 * @CreateTime: Nov 4, 2018 9:02 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 4, 2018 9:02 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.SalesOrders.Models {
    public class CustomerOrdersView {

       // private string _customerOrderId;
        public uint id { get; set; }
        public string customerName { get; set; }
        public string createdBy { get; set; }
        public string description { get; set; }
        public uint? totalQuantity { get; set; }
        public uint? totalProducts {get; set;}
        public double? totalPrice { get; set; }
        public double? totalCost { get; set; }
        public DateTime? createdOn { get; set; }
        public string status { get; set; }
        public DateTime? deliveryDate {get; set;}
        public DateTime? dateAdded{ get; set; }
        public DateTime? dateUpdated { get; set; }
    }
}