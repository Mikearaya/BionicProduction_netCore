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
using BionicInventory.Domain.CustomerOrders;
using BionicInventory.Domain.FinishedProducts;
using BionicProduction.Domain.StockBatchs;

namespace BionicInventory.Domain.Shipments {
    public partial class ShipmentDetail {
        public uint Id { get; set; }
        public uint ShipmentId { get; set; }
        public uint LotBookingId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public float? PickedQuantity { get; set; }
        public float BookedQuantity { get; set; }

        public virtual BookedStockBatch LotBooking { get; set; }
        public virtual Shipment Shipment { get; set; }
    }
}