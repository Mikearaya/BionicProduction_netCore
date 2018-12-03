/*
 * @CreateTime: Nov 29, 2018 2:34 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 3, 2018 8:51 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.Items.BOMs;
using BionicInventory.Domain.Items.ItemPrices;
using BionicInventory.Domain.ProductionOrders.ProductionOrderLists;
using BionicInventory.Domain.PurchaseOrders.PurchaseOrderDetails;
using BionicInventory.Domain.UnitOfMeasurments;

namespace BionicInventory.Domain.Items {
    public class Item {
        public Item () {
            BomItems = new HashSet<BomItems> ();
            ItemPrice = new HashSet<ItemPrice> ();
            ProductionOrderList = new HashSet<ProductionOrderList> ();
            PurchaseOrderDetail = new HashSet<PurchaseOrderDetail> ();
        }

        public uint Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public float? Weight { get; set; }
        public float UnitCost { get; set; }
        public string Photo { get; set; }
        public uint GroupId { get; set; }
        public sbyte? IsProcured { get; set; }
        public sbyte? IsInventory { get; set; }
        public float? Price { get; set; }
        public uint? ShelfLife { get; set; }
        public uint? ManufacturingUomId { get; set; }
        public float? MinimumQuantity { get; set; }
        public uint StoringUomId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdate { get; set; }

        public ProductGroup Group { get; set; }
        public UnitOfMeasurment ManufacturingUom { get; set; }
        public UnitOfMeasurment StoringUom { get; set; }
        public ICollection<BomItems> BomItems { get; set; }
        public ICollection<ItemPrice> ItemPrice { get; set; }
        public ICollection<ProductionOrderList> ProductionOrderList { get; set; }
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
    }
}