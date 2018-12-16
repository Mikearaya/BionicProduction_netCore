/*
 * @CreateTime: Dec 9, 2018 10:54 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 16, 2018 11:11 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.Items.Rotings;

namespace BionicInventory.Domain.Workstations {
    public class Workstation {
        public uint Id { get; set; }
        public string Title { get; set; }
        public double? HourlyRate { get; set; }
        public double? WorkingHours { get; set; }
        public double? HolidayHours { get; set; }
        public string Color { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public sbyte? IsActive { get; set; }
        public uint? Productivity { get; set; }
        public uint GroupId { get; set; }
        public float? MaintenanceHours { get; set; }
        public uint? MaintenanceItems { get; set; }

        public WorkstationGroup Group { get; set; }
    }

}