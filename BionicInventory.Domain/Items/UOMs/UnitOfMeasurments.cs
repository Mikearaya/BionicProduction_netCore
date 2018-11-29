/*
 * @CreateTime: Nov 29, 2018 11:25 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 29, 2018 11:26 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.Items.BOMs;

namespace BionicInventory.Domain.Items.UOMs {
    public partial class UnitOfMeasurments {
        public UnitOfMeasurments () {
            BomItems = new HashSet<BomItems> ();
            ItemManufacturingUom = new HashSet<Item> ();
            ItemStoringUom = new HashSet<Item> ();
        }

        public uint Id { get; set; }
        public string Abrivation { get; set; }
        public string Name { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public ICollection<BomItems> BomItems { get; set; }
        public ICollection<Item> ItemManufacturingUom { get; set; }
        public ICollection<Item> ItemStoringUom { get; set; }
    }
}