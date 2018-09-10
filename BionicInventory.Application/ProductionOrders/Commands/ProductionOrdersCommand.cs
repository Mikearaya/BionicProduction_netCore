/*
 * @CreateTime: Sep 10, 2018 8:32 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2018 11:30 PM
 * @Description: Modify Here, Please 
 */
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.ProductionOrders.Iterfaces;
using BionicInventory.Domain.ProductionOrders;
using BionicInventory.Domain.ProductionOrders.ProductionOrderLists;

namespace BionicInventory.Application.ProductionOrders.Commands {
    public class WorkOrdersCommand : IWorkOrdersCommand {
        private readonly IInventoryDatabaseService _database;
//TODO Eception handler for work order command class
        public WorkOrdersCommand (IInventoryDatabaseService database) {
            _database = database;

        }
        public ProductionOrder CreateNewWorkOrder (ProductionOrder newWorkOrder) {
            _database.ProductionOrder.Add(newWorkOrder);
            _database.Save();
            return newWorkOrder;
        }

        public bool DeleteWorkOrder(ProductionOrder deletedWorkOrder)
        {
            _database.ProductionOrder.Remove(deletedWorkOrder);
            _database.Save();
            return true;
        }
        public bool DeleteWorkOrderItem(ProductionOrderList deletedWorkOrder)
        {
            _database.ProductionOrderList.Remove(deletedWorkOrder);
            _database.Save();
            return true;
        }

        public ProductionOrder UpdateWorkOrder (ProductionOrder updatedWorkOrder) {
            _database.ProductionOrder.Update(updatedWorkOrder);
            _database.Save();
            return updatedWorkOrder;
        }
    }
}