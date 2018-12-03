/*
 * @CreateTime: Dec 3, 2018 10:00 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 3, 2018 10:03 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using BionicInventory.Domain.UnitOfMeasurments;

namespace BionicInventory.Application.UnitOfMeasurments.Queries {
    public class UnitOfMeasurmentView {
        public uint id { get; set; }
        public string name { get; set; }
        public string abbrevation { get; set; }

        public Boolean active { get; set; }

        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }

        public static Expression<Func<UnitOfMeasurment, UnitOfMeasurmentView>> Projection {
            get {
                return uom => new UnitOfMeasurmentView {
                    id = uom.Id,
                    name = uom.Name,
                    abbrevation = uom.Abrivation,
                    active = (uom.Active == 1) ? true : false,
                    dateAdded = uom.DateAdded,
                    dateUpdated = uom.DateUpdated

                };
            }
        }

        public static UnitOfMeasurmentView Create (UnitOfMeasurment uom) {
            return Projection.Compile ().Invoke (uom);
        }
    }
}