/*
 * @CreateTime: Dec 12, 2018 1:04 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 16, 2018 11:12 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.Items.Rotings;

namespace BionicInventory.Domain.Workstations {

    public partial class WorkstationGroup {
        public WorkstationGroup () {
            RoutingOperation = new HashSet<RoutingOperation> ();
            Workstation = new HashSet<Workstation> ();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public sbyte? Active { get; set; }

        public ICollection<RoutingOperation> RoutingOperation { get; set; }
        public ICollection<Workstation> Workstation { get; set; }
    }
}