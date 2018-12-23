using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class Item
    {
        public Item()
        {
            Bom = new HashSet<Bom>();
            BomItems = new HashSet<BomItems>();
            ProductionOrderList = new HashSet<ProductionOrderList>();
            PurchaseOrderDetail = new HashSet<PurchaseOrderDetail>();
            Routing = new HashSet<Routing>();
            StockBatch = new HashSet<StockBatch>();
            VendorPurchaseTerm = new HashSet<VendorPurchaseTerm>();
            WriteOff = new HashSet<WriteOff>();
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
        public uint PrimaryUomId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdate { get; set; }
        public uint DefaultStorageId { get; set; }

        public StorageLocation DefaultStorage { get; set; }
        public ProductGroup Group { get; set; }
        public UnitOfMeasurment PrimaryUom { get; set; }
        public ICollection<Bom> Bom { get; set; }
        public ICollection<BomItems> BomItems { get; set; }
        public ICollection<ProductionOrderList> ProductionOrderList { get; set; }
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
        public ICollection<Routing> Routing { get; set; }
        public ICollection<StockBatch> StockBatch { get; set; }
        public ICollection<VendorPurchaseTerm> VendorPurchaseTerm { get; set; }
        public ICollection<WriteOff> WriteOff { get; set; }
    }
}
