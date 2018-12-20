/*
 * @CreateTime: Dec 17, 2018 8:54 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 17, 2018 11:22 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BionicInventory.Domain.Items.Rotings;

namespace BionicInventory.Application.Routings.Models {
    public class RoutingDetailView {
        public uint id { get; set; }
        public string name { get; set; }
        public uint itemId { get; set; }
        public string itemName { get; set; }
        public uint itemGroupId { get; set; }
        public string itemGroupName { get; set; }
        public float? otherFixedCost { get; set; }
        public float? otherVariableCost { get; set; }
        public uint? quantity { get; set; }
        public double? fixedCost { get; set; }
        public double? approximateCost { get; set; }
        public double? approximateTime { get; set; }
        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }

        public IEnumerable<RoutingBomView> routingBoms = new List<RoutingBomView> ();
        public IEnumerable<RoutingOperationView> routingOperations = new List<RoutingOperationView> ();
        public static Expression<Func<Routing, RoutingDetailView>> Projection {

            get {
                return routing => new RoutingDetailView () {
                    id = routing.Id,
                    name = routing.Name,
                    itemId = routing.ItemId,
                    itemName = routing.Item.Name,
                    itemGroupId = routing.Item.GroupId,
                    otherFixedCost = routing.FixedCost,
                    otherVariableCost = routing.VariableCost,
                    quantity = routing.Quantity,
                    itemGroupName = routing.Item.Group.GroupName,
                    approximateCost =
                    ((routing.VariableCost * (double?) routing.Quantity) +
                    routing.RoutingOperation.Sum (o => o.VariableCost * (double?) o.Quantity) +
                    routing.RoutingOperation.Sum (o => o.FixedCost) + routing.FixedCost),
                    approximateTime =
                    routing.RoutingOperation.Sum (o => o.VariableTime * (double?) o.Quantity) + routing.RoutingOperation.Sum (o => o.FixedTime),
                    dateAdded = routing.DateAdded,
                    dateUpdated = routing.DateUpdated,
                    routingBoms = routing.RoutingBoms.AsQueryable ().Select (RoutingBomView.Projection),
                    routingOperations = routing.RoutingOperation.AsQueryable ().Select (RoutingOperationView.Projection)

                };
            }
        }

        public static RoutingDetailView Create (Routing routing) {
            return Projection.Compile ().Invoke (routing);
        }
    }

}