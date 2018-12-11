/*
 * @CreateTime: Dec 12, 2018 2:24 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2018 2:24 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BionicInventory.Domain.Workstations;

namespace BionicInventory.Application.Workstations.Models {
    public class WorkstationGroupDetailView {
        public uint id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool active { get; set; }

        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }

        public IEnumerable<WorkstationView> workstations { get; set; } = new List<WorkstationView> ();

        public static Expression<Func<WorkstationGroup, WorkstationGroupDetailView>> Projection {

            get {
                return station => new WorkstationGroupDetailView {
                    id = station.Id,
                    name = station.Name,
                    description = station.Description,
                    active = (station.Active != 0) ? true : false,
                    dateAdded = station.DateAdded,
                    dateUpdated = station.DateUpdated,
                    workstations = station.Workstation
                    .AsQueryable ()
                    .Select (WorkstationView.Projection)
                };
            }

        }

        public static WorkstationGroupDetailView Create (WorkstationGroup workstation) {
            return Projection.Compile ().Invoke (workstation);
        }

    }
}