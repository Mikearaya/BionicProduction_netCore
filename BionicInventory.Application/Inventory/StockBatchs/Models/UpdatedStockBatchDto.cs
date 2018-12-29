using System;

namespace BionicInventory.Application.Inventory.StockBatchs.Models {
    public class UpdatedStockBatchDto {
        public uint Id { get; set; }
        public string status { get; set; }
        public DateTime? AvailableFrom { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}