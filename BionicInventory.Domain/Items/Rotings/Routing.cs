/*
 * @CreateTime: Dec 9, 2018 10:52 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 9, 2018 10:52 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.Items.BOMs;

namespace BionicInventory.Domain.Items.Rotings {
    public class Routing {
        public Routing () {
            RoutingDetail = new HashSet<RoutingDetail> ();
        }

        public uint Id { get; set; }
        public uint BomId { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public float? FixedCost { get; set; }
        public float? VariableCost { get; set; }
        public uint? Quantity { get; set; }

        public Bom Bom { get; set; }
        public ICollection<RoutingDetail> RoutingDetail { get; set; }

    }
}