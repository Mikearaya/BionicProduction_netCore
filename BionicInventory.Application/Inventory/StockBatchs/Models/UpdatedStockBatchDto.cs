using System;

namespace BionicInventory.Application.Inventory.StockBatchs.Models {
    public class UpdatedStockBatchDto {
        public uint Id { get; set; }
        public float Quantity { get; set; }
        public float UnitCost { get; set; }
        public uint? PurchaseOrderId { get; set; }
        public uint? ManufactureOrderId { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}