/*
 * @CreateTime: Jan 10, 2019 7:41 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 10, 2019 8:00 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using BionicProduction.Domain.StockBatchs;

namespace BionicInventory.Application.Inventory.StockBatchs.Models {
    public class StockLotView {
        public uint id { get; set; }
        public uint itemId { get; set; }
        public string item { get; set; }
        public uint? manufactureOrderId { get; set; }
        public uint? purchaseOrderId { get; set; }
        public DateTime availableFrom { get; set; }
        public float quantity { get; set; }
        public float unitCost { get; set; }
        public string status { get; set; }
        public string source { get; set; }
        public DateTime? expiryDate { get; set; }
        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }
        public DateTime? arrivalDate { get; set; }

        public static Expression<Func<StockBatch, StockLotView>> Projection {
            get {
                return lot => new StockLotView () {
                    id = lot.Id,
                    itemId = lot.ItemId,
                    item = lot.Item.Name,
                    manufactureOrderId = lot.ManufactureOrderId,
                    purchaseOrderId = lot.PurchaseOrderId,
                    availableFrom = lot.AvailableFrom,
                    quantity = lot.Quantity,
                    unitCost = lot.UnitCost,
                    status = lot.Status,
                    source = lot.Source,
                    expiryDate = lot.ExpiryDate,
                    arrivalDate = lot.ArrivalDate,
                    dateAdded = lot.DateAdded,
                    dateUpdated = lot.DateUpdated

                };
            }
        }

        public StockLotView create (StockBatch lot) {
            return Projection.Compile ().Invoke (lot);
        }
    }
}