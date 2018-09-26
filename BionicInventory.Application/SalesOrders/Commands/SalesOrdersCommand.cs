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
        public IEnumerable<PurchaseOrder> CreateSalesOrder (IEnumerable<PurchaseOrder> orders) {
            _database.PurchaseOrder.AddRange (orders);
            _database.Save ();
            return orders;
        }

        public bool DeleteSalesOrders (PurchaseOrder order) {
            _database.PurchaseOrder.Remove (order);
            return true;
        }

        public bool UpdateSalesOrder (IEnumerable<PurchaseOrder> orders) {
            _database.PurchaseOrder.UpdateRange (orders);
            _database.Save ();
            return true;
        }
    }
}