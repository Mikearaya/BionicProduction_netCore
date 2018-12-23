/*
 * @CreateTime: Dec 23, 2018 9:48 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 23, 2018 9:54 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.Storages;
using BionicProduction.Domain.WriteOffs;

namespace BionicProduction.Domain.StockBatchs {
    public partial class StockBatchStorage {
        public StockBatchStorage () {
            InversePreviousStorageNavigation = new HashSet<StockBatchStorage> ();
            WriteOffDetail = new HashSet<WriteOffDetail> ();
        }

        public uint Id { get; set; }
        public uint BachId { get; set; }
        public uint StorageId { get; set; }
        public float Quantity { get; set; }
        public uint? PreviousStorage { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public StockBatch Bach { get; set; }
        public StockBatchStorage PreviousStorageNavigation { get; set; }
        public StorageLocation Storage { get; set; }
        public ICollection<StockBatchStorage> InversePreviousStorageNavigation { get; set; }
        public ICollection<WriteOffDetail> WriteOffDetail { get; set; }
    }
}