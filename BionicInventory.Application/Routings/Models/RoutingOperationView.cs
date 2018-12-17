/*
 * @CreateTime: Dec 17, 2018 8:14 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 17, 2018 8:14 PM
 * @Description: Modify Here, Please 
 */
/*
 * @CreateTime: Dec 17, 2018 8:08 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 17, 2018 8:42 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using BionicInventory.Domain.Items.Rotings;

namespace BionicInventory.Application.Routings.Models {
    public class RoutingOperationView {
        public uint id { get; set; }
        public uint routingId { get; set; }
        public string routing { get; set; }
        public uint workstationId { get; set; }
        public string workstation { get; set; }
        public string operation { get; set; }
        public double? fixedCost { get; set; }
        public double? variableCost { get; set; }
        public float? fixedTime { get; set; }
        public float? variableTime { get; set; }
        public int quantity { get; set; }
        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }

        public static Expression<Func<RoutingOperation, RoutingOperationView>> Projection {
            get {
                return operation => new RoutingOperationView () {
                    id = operation.Id,
                    operation = operation.Operation,
                    routingId = operation.RoutingId,
                    routing = operation.Routing.Name,
                    workstation = operation.Workstation.Name,
                    workstationId = operation.WorkstationId,
                    fixedCost = operation.FixedCost,
                    fixedTime = operation.FixedTime,
                    variableCost = operation.VariableCost,
                    variableTime = operation.VariableTime,
                    quantity = operation.Quantity,
                    dateAdded = operation.DateAdded,
                    dateUpdated = operation.DateUpdated,
                };
            }
        }

        public static RoutingOperationView create (RoutingOperation operation) {
            return Projection.Compile ().Invoke (operation);
        }

    }
}