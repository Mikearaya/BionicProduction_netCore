/*
 * @CreateTime: Dec 23, 2018 9:51 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 29, 2018 9:51 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.Items;

namespace BionicProduction.Domain.WriteOffs {
    public partial class WriteOff {
        public WriteOff () {
            WriteOffDetail = new HashSet<WriteOffDetail> ();
        }

        public uint Id { get; set; }
        public uint ItemId { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public string Type { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Item Item { get; set; }
        public ICollection<WriteOffDetail> WriteOffDetail { get; set; }
    }
}