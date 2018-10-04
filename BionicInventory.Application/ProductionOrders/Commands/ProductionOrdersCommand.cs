/*
 * @CreateTime: Sep 10, 2018 8:32 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2018 11:30 PM
 * @Description: Modify Here, Please 
 */
using System;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.ProductionOrders.Iterfaces;
using BionicInventory.Domain.ProductionOrders;
using BionicInventory.Domain.ProductionOrders.ProductionOrderLists;

namespace BionicInventory.Application.ProductionOrders.Commands {
    public class WorkOrdersCommand : IWorkOrdersCommand {
        private readonly IInventoryDatabaseService _database;

        public WorkOrdersCommand (IInventoryDatabaseService database) {
            _database = database;

        }
        public ProductionOrder CreateNewWorkOrder (ProductionOrder newWorkOrder) {


                _database.ProductionOrder.Add (newWorkOrder);
                _database.Save ();
                return newWorkOrder;

        }

        public bool DeleteWorkOrder (ProductionOrder deletedWorkOrder) {
            try {

                _database.ProductionOrder.Remove (deletedWorkOrder);
                _database.Save ();

                return true;

            } catch (Exception) {
                return false;
            }
        }
        public bool DeleteWorkOrderItem (ProductionOrderList deletedWorkOrder) {

            try {

                _database.ProductionOrderList.Remove (deletedWorkOrder);
                _database.Save ();

                return true;

            } catch (Exception) {
                return false;
            }
        }

        public ProductionOrder UpdateWorkOrder (ProductionOrder updatedWorkOrder) {

            try {

                _database.ProductionOrder.Update (updatedWorkOrder);
                _database.Save ();

                return updatedWorkOrder;

            } catch (Exception) {
                return null;
            }
        }
    }
}