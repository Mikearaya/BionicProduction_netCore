/*
 * @CreateTime: Nov 29, 2018 11:22 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 6, 2018 12:16 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;

namespace BionicInventory.Domain.Items.BOMs {
    public partial class Bom {
        public Bom () {
            BomItems = new HashSet<BomItems> ();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public uint ItemId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public sbyte? Active { get; set; }

        public Item Item { get; set; }
        public ICollection<BomItems> BomItems { get; set; }
    }
}