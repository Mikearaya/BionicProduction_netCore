/*
 * @CreateTime: Nov 29, 2018 11:23 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 4, 2018 10:18 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.UnitOfMeasurments;

namespace BionicInventory.Domain.Items.BOMs {
    public partial class BomItems {
        public uint Id { get; set; }
        public uint ItemId { get; set; }
        public string Note { get; set; }
        public uint Quantity { get; set; }
        public uint UomId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint BomId { get; set; }

        public Bom Bom { get; set; }
        public Item Item { get; set; }
        public UnitOfMeasurment Uom { get; set; }
    }
}