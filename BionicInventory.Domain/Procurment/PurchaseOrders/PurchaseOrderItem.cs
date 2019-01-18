/*
 * @CreateTime: Dec 29, 2018 9:40 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 29, 2018 9:41 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.Items;
using BionicProduction.Domain.StockBatchs;

namespace BionicInventory.Domain.Procurment.PurchaseOrders {
    public class PurchaseOrderItem {
        public PurchaseOrderItem () {
            StockBatch = new HashSet<StockBatch> ();
        }

        public uint Id { get; set; }
        public uint PurchaseOrderId { get; set; }
        public uint ItemId { get; set; }
        public float Quantity { get; set; }
        public float UnitPrice { get; set; }
        public DateTime ExpectedDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Item Item { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        public ICollection<StockBatch> StockBatch { get; set; }
    }
}