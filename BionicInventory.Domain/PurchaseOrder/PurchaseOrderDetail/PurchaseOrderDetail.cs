using System;
using System.Collections.Generic;
using BionicInventory.Domain.Items;
using BionicInventory.Domain.ProductionOrders.ProductionOrderLists;

namespace BionicInventory.Domain.PurchaseOrders.PurchaseOrderDetails
{
    public class PurchaseOrderDetail
    {
      public uint Id { get; set; }
        public uint PurchaseOrderId { get; set; }
        public uint ItemId { get; set; }
        public uint Quantity { get; set; }
        public float PricePerItem { get; set; }
        public float? AddedPricePerItem { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Item Item { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        public ProductionOrderList ProductionOrderList { get; set; }
    }
}
