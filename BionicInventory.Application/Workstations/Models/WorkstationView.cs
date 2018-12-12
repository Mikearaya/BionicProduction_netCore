using System;
using System.Linq.Expressions;
using BionicInventory.Domain.Workstations;

namespace BionicInventory.Application.Workstations.Models {
    public class WorkstationView {

        public uint id { get; set; }
        public string title { get; set; }
        public double? hourlyRate { get; set; }
        public double? workingHours { get; set; }
        public double? holidayHours { get; set; }
        public bool isActive { get; set; }
        public string color { get; set; }
        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }

        public static Expression<Func<Workstation, WorkstationView>> Projection {

            get {
                return station => new WorkstationView {
                    id = station.Id,
                    title = station.Title,
                    hourlyRate = (station.HourlyRate != null) ? station.HourlyRate : 0,
                    holidayHours = (station.HolidayHours != 0) ? station.HolidayHours : 0,
                    workingHours = (station.WorkingHours != 0) ? station.WorkingHours : 0,
                    isActive = (station.IsActive != 0) ? true : false,
                    color = station.Color,
                    dateAdded = station.DateAdded,
                    dateUpdated = station.DateUpdated
                };
            }

        }

        public static WorkstationView Create (Workstation workstation) {
            return Projection.Compile ().Invoke (workstation);
        }

    }
}