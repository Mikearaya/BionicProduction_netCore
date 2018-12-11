/*
 * @CreateTime: Dec 12, 2018 1:04 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2018 1:07 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;

namespace BionicInventory.Domain.Workstations {

    public partial class WorkstationGroup {
        public WorkstationGroup () {
            Workstation = new HashSet<Workstation> ();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public sbyte? Active { get; set; }

        public ICollection<Workstation> Workstation { get; set; }
    }
}