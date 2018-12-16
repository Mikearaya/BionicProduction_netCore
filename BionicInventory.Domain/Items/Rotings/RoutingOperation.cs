/*
 * @CreateTime: Dec 9, 2018 10:53 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 16, 2018 11:11 PM
 * @Description: Modify Here, Please 
 */
using System;
using BionicInventory.Domain.Employees;
using BionicInventory.Domain.Workstations;

namespace BionicInventory.Domain.Items.Rotings {
    public class RoutingOperation {
        public uint Id { get; set; }
        public uint RoutingId { get; set; }
        public uint WorkstationId { get; set; }
        public string Operation { get; set; }
        public double? FixedCost { get; set; }
        public double? VariableCost { get; set; }
        public float? FixedTime { get; set; }
        public float? VariableTime { get; set; }
        public int Quantity { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Routing Routing { get; set; }
        public WorkstationGroup Workstation { get; set; }
    }
}