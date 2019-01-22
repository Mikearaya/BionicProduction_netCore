/*
 * @CreateTime: Dec 27, 2018 11:45 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 30, 2018 8:01 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq;
using System.Linq.Expressions;
using BionicProduction.Domain.StockBatchs;

namespace BionicInventory.Application.Inventory.StockBatchs.Models {
    public class StockBatchListView {
        private float _quantity = 0;
        public uint id { get; set; }
        public uint itemId { get; set; }
        public float quantity {
            get {
                return _quantity;
            }
            set {
                _quantity = value;
            }
        }
        public float totalBooked { get; set; }
        public float unitCost { get; set; }
        public double? totalCost { get; set; }
        public string status { get; set; }
        public string storageLocation { get; set; }
        public uint storageLocationId { get; set; }
        public uint? purchaseOrderId { get; set; }
        public uint? manufactureOrderId { get; set; }
        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }
        public DateTime availableFrom { get; set; }
        public DateTime? expiryDate { get; set; }
        public string item { get; set; }
        public string itemGroup { get; set; }
        public uint itemGroupId { get; set; }
        public float totalWritenOff { get; set; }
        public string source { get; set; }

        public static Expression<Func<StockBatchStorage, StockBatchListView>> Projection {

            get {
                return batch => new StockBatchListView () {
                    id = batch.BatchId,
                    itemId = batch.Batch.ItemId,
                    item = batch.Batch.Item.Name,
                    status = batch.Batch.Status,
                    itemGroup = batch.Batch.Item.Group.GroupName,
                    itemGroupId = batch.Batch.Item.GroupId,
                    source = batch.Batch.Source,
                    quantity = batch.Quantity,
                    totalWritenOff = batch.WriteOffDetail.GroupBy (w => w.BatchStorage).Sum (w => w.Sum (sto => sto.Quantity)),
                    totalCost = (double) (batch.Quantity * batch.Batch.UnitCost),
                    storageLocation = batch.Storage.Name,
                    storageLocationId = batch.StorageId,
                    unitCost = batch.Batch.UnitCost,
                    totalBooked = batch.BookedStockBatch.Sum (b => b.Quantity),
                    manufactureOrderId = batch.Batch.ManufactureOrderId,
                    purchaseOrderId = batch.Batch.PurchaseOrderId,
                    availableFrom = batch.Batch.AvailableFrom,
                    dateAdded = batch.DateAdded,
                    dateUpdated = batch.DateUpdated,
                    expiryDate = batch.Batch.ExpiryDate,
                };
            }
        }

    }
}