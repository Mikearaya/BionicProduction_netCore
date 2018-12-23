/*
 * @CreateTime: Nov 29, 2018 2:34 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 23, 2018 10:20 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.Items.BOMs;
using BionicInventory.Domain.Items.Rotings;
using BionicInventory.Domain.ProductionOrders.ProductionOrderLists;
using BionicInventory.Domain.PurchaseOrders.PurchaseOrderDetails;
using BionicInventory.Domain.Storages;
using BionicInventory.Domain.UnitOfMeasurments;
using BionicInventory.Domain.Vendors;
using BionicProduction.Domain.StockBatchs;
using BionicProduction.Domain.WriteOffs;

namespace BionicInventory.Domain.Items {
    public class Item {
        public Item () {
            Bom = new HashSet<Bom> ();
            BomItems = new HashSet<BomItems> ();
            ProductionOrderList = new HashSet<ProductionOrderList> ();
            PurchaseOrderDetail = new HashSet<PurchaseOrderDetail> ();
            Routing = new HashSet<Routing> ();
            VendorPurchaseTerm = new HashSet<VendorPurchaseTerm> ();
            StockBatch = new HashSet<StockBatch> ();
            WriteOff = new HashSet<WriteOff> ();
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

        public uint DefaultStorageId { get; set; }

        public StorageLocation StorageLocation { get; set; }

        public ProductGroup Group { get; set; }
        public UnitOfMeasurment PrimaryUom { get; set; }
        public ICollection<Bom> Bom { get; set; }
        public ICollection<BomItems> BomItems { get; set; }
        public ICollection<ProductionOrderList> ProductionOrderList { get; set; }
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
        public ICollection<Routing> Routing { get; set; }
        public ICollection<VendorPurchaseTerm> VendorPurchaseTerm { get; set; }
        public ICollection<StockBatch> StockBatch { get; set; }
        public ICollection<WriteOff> WriteOff { get; set; }
    }
}