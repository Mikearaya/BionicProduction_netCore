/*
 * @CreateTime: Nov 29, 2018 2:34 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 6, 2018 12:20 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.Items.BOMs;
using BionicInventory.Domain.ProductionOrders.ProductionOrderLists;
using BionicInventory.Domain.PurchaseOrders.PurchaseOrderDetails;
using BionicInventory.Domain.UnitOfMeasurments;

namespace BionicInventory.Domain.Items {
    public class Item {
        public Item () {
            Bom = new HashSet<Bom> ();
            BomItems = new HashSet<BomItems> ();
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

        public float? MinimumQuantity { get; set; }
        public uint PrimaryUomId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdate { get; set; }

        public ProductGroup Group { get; set; }
        public UnitOfMeasurment PrimaryUom { get; set; }
        public ICollection<Bom> Bom { get; set; }
        public ICollection<BomItems> BomItems { get; set; }
        public ICollection<ProductionOrderList> ProductionOrderList { get; set; }
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
    }
}