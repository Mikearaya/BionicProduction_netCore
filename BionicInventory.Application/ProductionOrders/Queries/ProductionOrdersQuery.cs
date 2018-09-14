/*
 * @CreateTime: Sep 10, 2018 8:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2018 11:10 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.ProductionOrders.Iterfaces;
using BionicInventory.Domain.ProductionOrders;
using BionicInventory.Domain.ProductionOrders.ProductionOrderLists;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.ProductionOrders.Queries {
    public class WorkOrdersQuery : IWorkOrdersQuery {
        private readonly IInventoryDatabaseService _database;

        public WorkOrdersQuery (IInventoryDatabaseService database) {
            _database = database;
        }

        public IEnumerable<ProductionOrder> GetAllActiveWorkOrders () {
            //TODO Implement GetAllActiveWorkOrders
            throw new System.NotImplementedException ();
        }

        public IEnumerable<ProductionOrder> GetAllWorkOrders () {
            try {

                return _database.ProductionOrder.Include (p => p.ProductionOrderList).ToList ();

            } catch (Exception) {
                return null;
            }
        }

        public IEnumerable<ProductionOrder> GetCompletedWorkOrders () {
            //TODO Implement GetCompleteWorkOrders
            throw new System.NotImplementedException ();
        }

        public ProductionOrder GetWorkOrderById (uint id) {

            try {

                return _database.ProductionOrder.Where (order => order.Id == id).Include (order => order.ProductionOrderList).FirstOrDefault ();

            } catch (Exception) {
                return null;
            }
        }

        public ProductionOrderList GetWorkOrderItemById (uint id) {
            try {

                return _database.ProductionOrderList.FirstOrDefault (item => item.Id == id);

            } catch (Exception) {
                return null;
            }
        }
    }
}