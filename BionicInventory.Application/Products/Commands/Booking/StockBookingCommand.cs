/*
 * @CreateTime: Nov 2, 2018 9:19 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 10:11 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Products.Interfaces;
using BionicInventory.Application.Products.Interfaces.Booking;
using BionicInventory.Application.SalesOrders.Interfaces;
using BionicInventory.Domain.BookedStockItem;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Products.Commands.Booking {

    public class StockBookingCommand : IStockBookingCommand {
        private readonly IInventoryDatabaseService _database;
        private readonly ISalesOrderQuery _customerOrderQuery;
        private readonly ILogger<StockBookingCommand> _logger;
        private readonly IStockBookingQuery _stockQuery;

        public StockBookingCommand (IInventoryDatabaseService database,
            ILogger<StockBookingCommand> logger,
            ISalesOrderQuery saleOrderQuery,
            IStockBookingQuery query) {
            _database = database;
            _customerOrderQuery = saleOrderQuery;
            _logger = logger;
            _stockQuery = query;
        }
        public IList<BookedStockItems> BookAvailableStockItems (IList<BookedStockItems> bookedItems) {

                _database.BookedStockItems.AddRange(bookedItems);
                _database.Save();
                return bookedItems;
            
        }

    }
}