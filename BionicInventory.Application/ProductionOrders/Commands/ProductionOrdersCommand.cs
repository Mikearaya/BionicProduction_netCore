/*
 * @CreateTime: Sep 10, 2018 8:32 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2018 8:43 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.ProductionOrders.Iterfaces;
using BionicInventory.Domain.ProductionOrders;

namespace BionicInventory.Application.ProductionOrders.Commands {
    public class WorkOrdersCommand : IWorkOrdersCommand {
        public void Create () {
            throw new System.NotImplementedException ();
        }

        public ProductionOrder CreateNewWorkOrder (ProductionOrder newWorkOrder) {
            throw new System.NotImplementedException ();
        }

        public void Delete () {
            throw new System.NotImplementedException ();
        }

        public bool DeleteWorkOrderById (uint id) {
            throw new System.NotImplementedException ();
        }

        public bool DeleteWorkOrderItemById (uint id) {
            throw new System.NotImplementedException ();
        }

        public void Update () {
            throw new System.NotImplementedException ();
        }

        public ProductionOrder UpdateWorkOrder (ProductionOrder newWorkOrder) {
            throw new System.NotImplementedException ();
        }
    }
}