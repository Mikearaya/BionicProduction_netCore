/*
 * @CreateTime: Nov 14, 2018 11:05 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 14, 2018 11:06 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.FinishedProducts;
using BionicInventory.Domain.PurchaseOrders.PurchaseOrderDetails;

namespace BionicInventory.Domain.Shipments.ShipmentDetails {
    public  class ShipmentDetail {
        public uint Id { get; set; }
        public uint ShipmentId { get; set; }
        public uint StockId { get; set; }
        public uint OrderItemId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public sbyte? Picked { get; set; }

        public PurchaseOrderDetail OrderItem { get; set; }
        public Shipment Shipment { get; set; }
        public FinishedProduct Stock { get; set; }
    }
}