/*
 * @CreateTime: Sep 10, 2018 8:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2018 8:33 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.ProductionOrders.Models {
    public class WorkOrderView {
        public uint id;
        public string orderedBy;
        public string description;

        public uint orderId;

        public string product;

        public uint costPerItem;
        public DateTime dueDate;
        public DateTime orderDate;

        public uint quantity;
    }
}