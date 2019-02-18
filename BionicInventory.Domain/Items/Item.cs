/*
 * @CreateTime: Nov 29, 2018 2:34 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 18, 2019 9:38 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.CustomerOrders;
using BionicInventory.Domain.Items.BOMs;
using BionicInventory.Domain.Items.Rotings;
using BionicInventory.Domain.Procurment.PurchaseOrders;
using BionicInventory.Domain.Procurment.Vendors;
using BionicInventory.Domain.ProductionOrders;
using BionicInventory.Domain.Storages;
using BionicInventory.Domain.UnitOfMeasurments;
using BionicProduction.Domain.StockBatchs;
using BionicProduction.Domain.WriteOffs;

namespace BionicInventory.Domain.Items {
    public partial class Item {

        public Item () {
            Bom = new HashSet<Bom> ();
            BomItems = new HashSet<BomItems> ();
            CustomerOrderItem = new HashSet<CustomerOrderItem> ();
            ProductionOrderList = new HashSet<ProductionOrderList> ();
            PurchaseOrderQuotation = new HashSet<PurchaseOrderQuotation> ();
            Routing = new HashSet<Routing> ();
            StockBatch = new HashSet<StockBatch> ();
            VendorPurchaseTerm = new HashSet<VendorPurchaseTerm> ();
            WriteOff = new HashSet<WriteOff> ();
        }

        public uint Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public float? Weight { get; set; }
        public float UnitCost { get; set; }
        public string Photo { get; set; }
        public float? MinimumQuantity { get; set; }
        public uint GroupId { get; set; }
        public sbyte? IsProcured { get; set; }
        public sbyte? IsInventory { get; set; }
        public float? Price { get; set; }
        public uint? ShelfLife { get; set; }
        public uint PrimaryUomId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdate { get; set; }
        public uint DefaultStorageId { get; set; }

        public virtual StorageLocation DefaultStorage { get; set; }
        public virtual ProductGroup Group { get; set; }
        public virtual UnitOfMeasurment PrimaryUom { get; set; }
        public virtual ICollection<Bom> Bom { get; set; }
        public virtual ICollection<BomItems> BomItems { get; set; }
        public virtual ICollection<CustomerOrderItem> CustomerOrderItem { get; set; }
        public virtual ICollection<ProductionOrderList> ProductionOrderList { get; set; }
        public virtual ICollection<PurchaseOrderQuotation> PurchaseOrderQuotation { get; set; }
        public virtual ICollection<Routing> Routing { get; set; }
        public virtual ICollection<StockBatch> StockBatch { get; set; }
        public virtual ICollection<VendorPurchaseTerm> VendorPurchaseTerm { get; set; }
        public virtual ICollection<WriteOff> WriteOff { get; set; }
    }
}