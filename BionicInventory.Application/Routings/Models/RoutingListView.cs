/*
 * @CreateTime: Dec 17, 2018 12:23 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 17, 2018 12:43 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq;
using System.Linq.Expressions;
using BionicInventory.Domain.Items.Rotings;

namespace BionicInventory.Application.Routings.Models {
    public class RoutingListView {
        public uint id { get; set; }
        public string name { get; set; }
        public uint itemId { get; set; }
        public string itemName { get; set; }
        public uint itemGroupId { get; set; }
        public string itemGroupName { get; set; }
        public double? approximateCost { get; set; }
        public double? approximateTime { get; set; }
        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }

        public static Expression<Func<Routing, RoutingListView>> Projection {

            get {
                return routing => new RoutingListView {
                    id = routing.Id,
                    name = routing.Name,
                    itemId = routing.ItemId,
                    itemName = routing.Item.Name,
                    itemGroupId = routing.Item.GroupId,
                    itemGroupName = routing.Item.Group.GroupName,
                    approximateCost =
                    ((routing.VariableCost * routing.Quantity) +
                    routing.RoutingOperation.Sum (o => o.VariableCost * o.Quantity) +
                    routing.RoutingOperation.Sum (o => o.FixedCost) + routing.FixedCost),
                    approximateTime =
                    routing.RoutingOperation.Sum (o => o.VariableTime * o.Quantity) + routing.RoutingOperation.Sum (o => o.FixedTime),
                    dateAdded = routing.DateAdded,
                    dateUpdated = routing.DateUpdated,
                };
            }

        }

        public static RoutingListView Create (Routing routing) {
            return Projection.Compile ().Invoke (routing);
        }
    }
}