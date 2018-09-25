using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database {
    public partial class ProductionOrderList {
        public ProductionOrderList () {
            FinishedProduct = new HashSet<FinishedProduct> ();
        }

        public uint Id { get; set; }
        public uint ProductionOrderId { get; set; }
        public uint ItemId { get; set; }
        public uint Quantity { get; set; }
        public float CostPerItem { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime DueDate { get; set; }
        public uint? PurchaseOrderId { get; set; }

        public Item Item { get; set; }
        public ProductionOrder ProductionOrder { get; set; }
        public PurchaseOrderDetail PurchaseOrder { get; set; }
        public ICollection<FinishedProduct> FinishedProduct { get; set; }
    }
}