/*
 * @CreateTime: Dec 17, 2018 8:21 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 17, 2018 8:27 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using BionicInventory.Domain.Routings;

namespace BionicInventory.Application.Routings.Models {
    public class RoutingBomView {
        public uint id { get; set; }
        public uint routingId { get; set; }
        public string routing { get; set; }
        public uint bomId { get; set; }
        public string bom { get; set; }
        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }

        public static Expression<Func<RoutingBoms, RoutingBomView>> Projection {
            get {
                return routebom => new RoutingBomView () {
                    id = routebom.Id,
                    routingId = routebom.RoutingId,
                    routing = routebom.Routing.Name,
                    bom = routebom.Bom.Name,
                    bomId = routebom.BomId,
                    dateAdded = routebom.DateAdded,
                    dateUpdated = routebom.DateUpdated

                };
            }
        }

        public static RoutingBomView create (RoutingBoms routingBom) {
            return Projection.Compile ().Invoke (routingBom);
        }

    }
}