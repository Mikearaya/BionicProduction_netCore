using System;
using System.Collections.Generic;
using BionicInventory.Domain.Items.ItemPrices;
using BionicInventory.Domain.ProductionOrders.ProductionOrderLists;
using BionicInventory.Domain.PurchaseOrders.PurchaseOrderDetails;

namespace BionicInventory.Domain.Items
{
    public class Item
    {
        public Item()
        {
            ItemPrice = new HashSet<ItemPrice>();
            ProductionOrderList = new HashSet<ProductionOrderList>();
            PurchaseOrderDetail = new HashSet<PurchaseOrderDetail>();
        }

        public uint Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public string Unit { get; set; }
        public string Description { get; set; }
        public float UnitCost { get; set; }
        public float Weight { get; set; }
        public string Photo { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdate { get; set; }

        public ICollection<ItemPrice> ItemPrice { get; set; }
        public ICollection<ProductionOrderList> ProductionOrderList { get; set; }
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
    }
}
