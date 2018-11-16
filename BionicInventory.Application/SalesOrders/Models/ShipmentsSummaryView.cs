/*
 * @CreateTime: Nov 15, 2018 7:05 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 15, 2018 7:05 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.SalesOrders.Models {
    public class ShipmentsSummaryView {

        public uint id { get; set; }
        public uint shipmentId { get; set; }
        public uint customerOrderItemId { get; set; }
        public DateTime createdOn { get; set; }
        public double amount { get; set; }
        public DateTime dateUpdated { get; set; }

    }
}