/*
 * @CreateTime: Dec 13, 2018 12:08 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 13, 2018 12:08 AM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Domain.Storages {
    public class StorageLocation {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public sbyte? Active { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}