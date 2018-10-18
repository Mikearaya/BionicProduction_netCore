/*
 * @CreateTime: Oct 1, 2018 9:37 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 1, 2018 9:37 PM
 * @Description: Modify Here, Please 
 */
/*
 * @CreateTime: Sep 10, 2018 8:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 18, 2018 9:59 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.ProductionOrders.Models {
    public class WorkOrderView {
    

        public uint id { get; set; }
        public string orderedBy { get; set; }
        public uint orderedById { get; set; }
        public string description { get; set; }
        public uint? salesOrderItemId { get; set; }

        public string product { get; set; }
        public double? cost {get; set;}
        public string productName {get; set;}
        public uint productId {get; set;}
        public DateTime? start { get; set; }
        public DateTime? dueDate { get; set; }
        public DateTime? orderDate { get; set; }

        public int quantity { get; set; }

        public string customer { get; set; }

    }
}