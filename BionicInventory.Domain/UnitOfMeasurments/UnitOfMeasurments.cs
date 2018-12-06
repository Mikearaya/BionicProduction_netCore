/*
 * @CreateTime: Dec 3, 2018 8:40 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 3, 2018 8:42 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.Items;
using BionicInventory.Domain.Items.BOMs;

namespace BionicInventory.Domain.UnitOfMeasurments {
    public class UnitOfMeasurment {

        public UnitOfMeasurment () {
            BomItems = new HashSet<BomItems> ();
            ItemPrimaryUom = new HashSet<Item> ();
        }

        public uint Id { get; set; }
        public string Abrivation { get; set; }
        public string Name { get; set; }
        public sbyte? Active { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public ICollection<BomItems> BomItems { get; set; }
        public ICollection<Item> ItemPrimaryUom { get; set; }

    }
}