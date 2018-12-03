/*
 * @CreateTime: Nov 29, 2018 11:22 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 3, 2018 8:50 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;

namespace BionicInventory.Domain.Items.BOMs {
    public partial class Bom {

        public Bom () {
            InverseItem = new HashSet<Bom> ();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public uint ItemId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Bom Item { get; set; }
        public ICollection<Bom> InverseItem { get; set; }
    }
}