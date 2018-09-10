/*
 * @CreateTime: Sep 10, 2018 8:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2018 10:01 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.ProductionOrders.Iterfaces;
using BionicInventory.Domain.ProductionOrders;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.ProductionOrders.Queries {
    public class WorkOrdersQuery : IWorkOrdersQuery {
        private readonly IInventoryDatabaseService _database;

        public WorkOrdersQuery(IInventoryDatabaseService database) {
            _database = database;
        }

        public IEnumerable<ProductionOrder> GetAllActiveWorkOrders () {
            //TODO
            throw new System.NotImplementedException ();
        }

        public IEnumerable<ProductionOrder> GetAllWorkOrders () {
           return _database.ProductionOrder.Include(p => p.ProductionOrderList ).ToList();
        }

        public ProductionOrder GetById (uint id) {
            throw new System.NotImplementedException ();
        }

        public IEnumerable<ProductionOrder> GetCompletedWorkOrders () {
            throw new System.NotImplementedException ();
        }

        public ProductionOrder GetWorkOrderById (uint id) {
            throw new System.NotImplementedException ();
        }
    }
}