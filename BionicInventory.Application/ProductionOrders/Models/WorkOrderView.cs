/*
 * @CreateTime: Sep 10, 2018 8:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 29, 2018 11:45 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.ProductionOrders.Models {
    public class WorkOrderView {
        public uint id { get; set; }
        public string orderedBy { get; set; }
        public string description { get; set; }

        public uint orderId { get; set; }

        public string product { get; set; }

        public DateTime? dueDate { get; set; }
        public DateTime? orderDate { get; set; }

        public int quantity { get; set; }
        public int remaining { get; set; }

        public int completed { get; set; }

        // test purpose

        public int booked {get; set;}
        public int available {get; set;}
        public long expectedAvailable {get; set;}
        public long expectedBooked {get; set;}
        

        public string client { get; set; }

        public string status { get; set; }
    }
}