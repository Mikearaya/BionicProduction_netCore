/*
 * @CreateTime: Dec 30, 2018 8:02 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 30, 2018 9:05 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BionicProduction.Domain.StockBatchs;

namespace BionicInventory.Application.Inventory.StockBatchs.Models {
    public class StockBatchDetailView {
        public StockBatchDetailView () {
            storages = new List<StockBatchStorageView> ();
        }
        private float _quantity = 0;

        public uint id { get; set; }
        public uint itemId { get; set; }
        public float quantity {
            get {
                return _quantity - totalWriteOff;
            }
            set {
                _quantity = value;
            }
        }
        public float? totalBooked { get; set; }
        public float unitCost { get; set; }
        public string status { get; set; }
        public uint? purchaseOrderId { get; set; }
        public uint? manufactureOrderId { get; set; }
        public float totalWriteOff { get; set; }
        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }
        public DateTime availableFrom { get; set; }
        public DateTime? expiryDate { get; set; }
        public string item { get; set; }
        public string itemGroup { get; set; }
        public uint itemGroupId { get; set; }
        public string source { get; set; }

        public IEnumerable<StockBatchStorageView> storages { get; set; }

        public static Expression<Func<StockBatch, StockBatchDetailView>> Projection {

            get {
                return stock => new StockBatchDetailView () {
                    id = stock.Id,
                    item = stock.Item.Name,
                    itemId = stock.ItemId,
                    quantity = stock.Quantity,
                    totalBooked = stock.StockBatchStorage
                    .Sum (stored => stored.BookedStockBatch
                    .Sum (booked => booked.Quantity)),
                    unitCost = stock.UnitCost,
                    status = stock.Status,
                    purchaseOrderId = stock.PurchaseOrderId,
                    manufactureOrderId = stock.ManufactureOrderId,
                    dateAdded = stock.DateAdded,
                    dateUpdated = stock.DateUpdated,
                    availableFrom = stock.AvailableFrom,
                    source = stock.Source,
                    expiryDate = stock.ExpiryDate,
                    itemGroup = stock.Item.Group.GroupName,
                    itemGroupId = stock.Item.GroupId,
                    storages = stock.StockBatchStorage.AsQueryable ().Select (StockBatchStorageView.Projection)
                };
            }

        }

    }
}