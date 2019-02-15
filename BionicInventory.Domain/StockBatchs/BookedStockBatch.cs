/*
 * @CreateTime: Dec 23, 2018 9:58 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 29, 2018 9:52 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.CustomerOrders;
using BionicInventory.Domain.ProductionOrders;
using BionicInventory.Domain.Shipments;

namespace BionicProduction.Domain.StockBatchs {
    public partial class BookedStockBatch {
        public BookedStockBatch () {
            ShipmentDetail = new HashSet<ShipmentDetail> ();
        }

        public uint Id { get; set; }
        public uint? BatchStorageId { get; set; }
        public uint? CustomerOrderId { get; set; }
        public uint? ProductionOrderId { get; set; }
        public float Quantity { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public float? ConsumedQuantity { get; set; }

        public virtual StockBatchStorage BatchStorage { get; set; }
        public virtual CustomerOrderItem CustomerOrder { get; set; }
        public virtual ProductionOrderList ProductionOrder { get; set; }
        public virtual ICollection<ShipmentDetail> ShipmentDetail { get; set; }
    }
}