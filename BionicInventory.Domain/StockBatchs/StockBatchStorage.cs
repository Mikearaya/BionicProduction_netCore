/*
 * @CreateTime: Dec 23, 2018 9:48 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 29, 2018 2:14 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.Storages;
using BionicProduction.Domain.WriteOffs;

namespace BionicProduction.Domain.StockBatchs {
    public partial class StockBatchStorage {
        public StockBatchStorage () {
            BookedStockBatch = new HashSet<BookedStockBatch> ();
            WriteOffDetail = new HashSet<WriteOffDetail> ();
        }

        public uint Id { get; set; }
        public uint BatchId { get; set; }
        public uint StorageId { get; set; }
        public float Quantity { get; set; }
        public uint? PreviousStorage { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public StockBatch Batch { get; set; }
        public StorageLocation Storage { get; set; }
        public ICollection<BookedStockBatch> BookedStockBatch { get; set; }
        public ICollection<WriteOffDetail> WriteOffDetail { get; set; }
    }
}