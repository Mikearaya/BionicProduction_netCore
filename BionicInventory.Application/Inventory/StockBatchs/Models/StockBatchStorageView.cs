/*
 * @CreateTime: Dec 30, 2018 8:03 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 30, 2018 8:10 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using BionicProduction.Domain.StockBatchs;

namespace BionicInventory.Application.Inventory.StockBatchs.Models {
    public class StockBatchStorageView {
        public uint id { get; set; }
        public uint batchId { get; set; }
        public uint storageId { get; set; }
        public string storage { get; set; }
        public uint? previousStorageId { get; set; }
        public string previousStorage { get; set; }
        public float quantity { get; set; }
        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }

        public static Expression<Func<StockBatchStorage, StockBatchStorageView>> Projection {

            get {
                return storage => new StockBatchStorageView () {
                    id = storage.Id,
                    batchId = storage.BatchId,
                    storageId = storage.StorageId,
                    storage = storage.Storage.Name,
                    previousStorage = storage.PreviousStorage.Storage.Name,
                    previousStorageId = storage.PreviousStorageId,
                    quantity = storage.Quantity,
                    dateAdded = storage.DateAdded,
                    dateUpdated = storage.DateUpdated
                };
            }
        }
    }
}