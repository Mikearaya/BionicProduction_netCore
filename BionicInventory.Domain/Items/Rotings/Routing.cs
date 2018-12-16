/*
 * @CreateTime: Dec 9, 2018 10:52 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 16, 2018 11:49 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.Items.BOMs;
using BionicInventory.Domain.Routings;

namespace BionicInventory.Domain.Items.Rotings {
    public class Routing {
        public Routing () {
            RoutingBoms = new HashSet<RoutingBoms> ();
            RoutingOperation = new HashSet<RoutingOperation> ();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public float? FixedCost { get; set; }
        public float? VariableCost { get; set; }
        public uint? Quantity { get; set; }
        public uint ItemId { get; set; }

        public Item Item { get; set; }
        public ICollection<RoutingBoms> RoutingBoms { get; set; }
        public ICollection<RoutingOperation> RoutingOperation { get; set; }

    }
}