/*
 * @CreateTime: Dec 27, 2018 11:45 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 27, 2018 11:45 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.Inventory.StockBatchs.Models {
    public class StockBatchView {
        public uint Id { get; set; }
        public uint ItemId { get; set; }
        public float Quantity { get; set; }
        public float UnitCost { get; set; }
        public string Status { get; set; }
        public uint? PurchaseOrderId { get; set; }
        public uint? ManufactureOrderId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime? ExpiryDate { get; set; }

        //  public Item Item { get; set; }
        //     public ICollection<BookedStockBatch> BookedStockBatch { get; set; }
        //      public ICollection<StockBatchStorage> StockBatchStorage { get; set; }
    }
}