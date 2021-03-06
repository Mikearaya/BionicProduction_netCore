/*
 * @CreateTime: Nov 24, 2018 9:23 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 24, 2018 9:23 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.SalesOrders.Interfaces;
using BionicInventory.Domain.CustomerOrders;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.SalesOrders.Commands {
    public class SalesOrderCommand : ISalesOrderCommand {
        private readonly IInventoryDatabaseService _database;
        private readonly ILogger<SalesOrderCommand> _logger;

        public SalesOrderCommand (IInventoryDatabaseService database,
            ILogger<SalesOrderCommand> logger) {
            _database = database;
            _logger = logger;
        }
        public CustomerOrder CreateSalesOrder (CustomerOrder order) {

            _database.CustomerOrder.Add (order);
            _database.Save ();
            return order;
        }

        public bool DeleteSalesOrders (CustomerOrder order) {
            _database.CustomerOrder.Remove (order);
            _database.Save ();
            return true;
        }

        public bool UpdateSalesOrder (CustomerOrder orders) {
            _database.CustomerOrder.Update (orders);
            _database.Save ();
            return true;
        }
    }
}