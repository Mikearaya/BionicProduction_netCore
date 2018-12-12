using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class Workstation
    {
        public Workstation()
        {
            RoutingDetail = new HashSet<RoutingDetail>();
        }

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
        public ICollection<RoutingDetail> RoutingDetail { get; set; }
    }
}
