/*
 * @CreateTime: Dec 23, 2018 9:51 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 29, 2018 9:54 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.Items;
using BionicInventory.Domain.Procurment.PurchaseOrders;
using BionicInventory.Domain.ProductionOrders;

namespace BionicProduction.Domain.StockBatchs {
    public partial class StockBatch {
        public StockBatch () {
            StockBatchStorage = new HashSet<StockBatchStorage> ();
        }

        public uint Id { get; set; }
        public uint ItemId { get; set; }
        public uint? ManufactureOrderId { get; set; }
        public uint? PurchaseOrderId { get; set; }
        public DateTime AvailableFrom { get; set; }
        public float Quantity { get; set; }
        public float UnitCost { get; set; }
        public string Status { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public string Source { get; set; }

        public Item Item { get; set; }
        public ProductionOrderList ManufactureOrder { get; set; }
        public PurchaseOrderItem PurchaseOrder { get; set; }
        public ICollection<StockBatchStorage> StockBatchStorage { get; set; }

    }
}