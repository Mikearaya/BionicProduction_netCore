/*
 * @CreateTime: Jan 1, 2019 8:40 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 9:22 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq;
using System.Linq.Expressions;
using BionicProduction.Domain.WriteOffs;

namespace BionicInventory.Application.Stocks.WriteOffs.Models {
    public class WriteOffItemListView {

        private float _batchQuantity = 0;
        private float _quantity = 0;
        private float _unitCost = 0;
        public uint id { get; set; }
        public uint batchStorageId { get; set; }
        public uint batchId { get; set; }
        public string storage { get; set; }

        public uint storageId { get; set; }
        public string item { get; set; }
        public string uom { get; set; }
        public string batchStatus { get; set; }
        public float totalBooked { get; set; }
        public uint itemId { get; set; }
        public uint writeOffId { get; set; }

        public float totalCost { get; set; }
        public float unitCost {
            get {
                return _unitCost;
            }
            set {
                _unitCost = value;
                calculateTotalCost ();
            }
        }

        public float batchQuantity {
            get {
                return _batchQuantity;
            }
            set {
                _batchQuantity = value;
            }
        }
        public float quantity {
            get {
                return _quantity;
            }
            set {
                _quantity = value;
                calculateTotalCost ();
            }
        }
        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }
        private void calculateTotalCost () {
            totalCost = unitCost * quantity;
        }

        public static Expression<Func<WriteOffDetail, WriteOffItemListView>> Projection {
            get {
                return writeoff_detail => new WriteOffItemListView () {
                    id = writeoff_detail.Id,
                    batchId = writeoff_detail.BatchStorage.BatchId,
                    batchStatus = writeoff_detail.BatchStorage.Batch.Status,
                    batchStorageId = writeoff_detail.BatchStorageId,
                    storage = writeoff_detail.BatchStorage.Storage.Name,
                    storageId = writeoff_detail.BatchStorage.StorageId,
                    item = writeoff_detail.BatchStorage.Batch.Item.Name,
                    uom = writeoff_detail.BatchStorage.Batch.Item.PrimaryUom.Name,
                    itemId = writeoff_detail.BatchStorage.Batch.ItemId,
                    writeOffId = writeoff_detail.WriteOffId,
                    quantity = writeoff_detail.Quantity,
                    batchQuantity = writeoff_detail.BatchStorage.Quantity,
                    unitCost = writeoff_detail.BatchStorage.Batch.UnitCost,
                    dateAdded = writeoff_detail.DateAdded,
                    dateUpdated = writeoff_detail.DateUpdated
                };
            }
        }

        public static WriteOffItemListView create (WriteOffDetail writeoff_detail) {
            return Projection.Compile ().Invoke (writeoff_detail);
        }

    }
}