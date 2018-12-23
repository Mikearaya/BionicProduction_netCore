/*
 * @CreateTime: Dec 13, 2018 12:08 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 23, 2018 10:28 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.Items;
using BionicProduction.Domain.StockBatchs;

namespace BionicInventory.Domain.Storages {
    public class StorageLocation {
        public StorageLocation () {
            Item = new HashSet<Item> ();
            StockBatchStorage = new HashSet<StockBatchStorage> ();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public sbyte? Active { get; set; }

        public ICollection<Item> Item { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public ICollection<StockBatchStorage> StockBatchStorage { get; set; }

    }
}