using System.Collections.Generic;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.SalesOrders.Interfaces;
using BionicInventory.Domain.PurchaseOrders;
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
        public PurchaseOrder CreateSalesOrder (PurchaseOrder order) {

            _database.PurchaseOrder.Add (order);
            _database.Save ();
            return order;
        }

        public bool DeleteSalesOrders (PurchaseOrder order) {
            _database.PurchaseOrder.Remove (order);
            return true;
        }

        public bool UpdateSalesOrder (PurchaseOrder orders) {
            _database.PurchaseOrder.Update (orders);
            _database.Save ();
            return true;
        }
    }
}