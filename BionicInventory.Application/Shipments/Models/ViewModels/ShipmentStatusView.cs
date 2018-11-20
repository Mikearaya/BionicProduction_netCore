/*
 * @CreateTime: Nov 16, 2018 7:11 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 16, 2018 7:11 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.Shipments.Models.ViewModels {
    public class ShipmentStatusView {
        public uint id { get; set; }
        public uint CustomerOrderId { get; set; }
        public uint bookingUserId { get; set; }
        public string bookingUser { get; set; }
        public string status { get; set; }
        public DateTime deliveryDate { get; set; }
        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }

    }
}