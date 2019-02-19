/*
 * @CreateTime: Jan 10, 2019 8:01 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 19, 2019 9:38 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using BionicProduction.Domain.StockBatchs;

namespace BionicInventory.Application.Stocks.StockLots.Models {
    public class StockLotStorageView {
        public uint id { get; set; }
        public uint batchId { get; set; }
        public uint storageId { get; set; }
        public string storage { get; set; }
        public uint? previousStorageId { get; set; }
        public string previousStorage { get; set; }
        public float quantity { get; set; }
        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }

        public static Expression<Func<StockBatchStorage, StockLotStorageView>> Projection {

            get {
                return storage => new StockLotStorageView () {
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

        public static Expression<Func<StockBatchStorage, string>> StoragesProjection {

            get {
                return storage => storage.Storage.Name;
            }
        }

        public StockLotStorageView Create (StockBatchStorage lotStorage) {
            return Projection.Compile ().Invoke (lotStorage);
        }

    }
}