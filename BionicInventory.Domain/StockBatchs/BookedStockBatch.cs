/*
 * @CreateTime: Dec 23, 2018 9:58 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 23, 2018 9:58 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.ProductionOrders.ProductionOrderLists;
using BionicInventory.Domain.PurchaseOrders.PurchaseOrderDetails;

namespace BionicProduction.Domain.StockBatchs {
    public partial class BookedStockBatch {
        public uint Id { get; set; }
        public uint? BatchStorageId { get; set; }
        public uint? ProductionOrderId { get; set; }
        public uint? CustomerOrderId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public float Quantity { get; set; }

        public StockBatch BatchStorage { get; set; }
        public PurchaseOrderDetail CustomerOrder { get; set; }
        public ProductionOrderList ProductionOrder { get; set; }
    }
}