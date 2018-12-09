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
        public sbyte? CustomeWorkingHoures { get; set; }
        public sbyte? CustomHolidays { get; set; }
        public string Color { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public ICollection<RoutingDetail> RoutingDetail { get; set; }
    }
}
