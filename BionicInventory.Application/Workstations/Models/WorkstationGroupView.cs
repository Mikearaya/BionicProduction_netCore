using System;
using System.Linq.Expressions;
using BionicInventory.Domain.Workstations;

namespace BionicInventory.Application.Workstations.Models {
    public class WorkstationGroupView {
        public uint id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool active { get; set; }

        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }

        public static Expression<Func<WorkstationGroup, WorkstationGroupView>> Projection {

            get {
                return station => new WorkstationGroupView {
                    id = station.Id,
                    name = station.Name,
                    description = station.Description,
                    active = (station.Active != 0) ? true : false,
                    dateAdded = station.DateAdded,
                    dateUpdated = station.DateUpdated,
                };
            }

        }

        public static WorkstationGroupView Create (WorkstationGroup workstation) {
            return Projection.Compile ().Invoke (workstation);
        }

    }
}