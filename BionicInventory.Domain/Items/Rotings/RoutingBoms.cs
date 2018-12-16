/*
 * @CreateTime: Dec 16, 2018 10:43 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 16, 2018 10:43 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.Items.BOMs;
using BionicInventory.Domain.Items.Rotings;

namespace BionicInventory.Domain.Routings {
    public partial class RoutingBoms {
        public uint Id { get; set; }
        public uint RoutingId { get; set; }
        public uint BomId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Bom Bom { get; set; }
        public Routing Routing { get; set; }
    }
}