/*
 * @CreateTime: Sep 15, 2018 11:34 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 27, 2018 4:20 PM
 * @Description: Customer Command Class
 */

using System;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Customers.Interfaces;
using BionicInventory.Application.Customers.Models;
using BionicInventory.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Customers.Commands {
    public class CustomersCommand : ICustomersCommand {
        private readonly IInventoryDatabaseService _database;
        private readonly ILogger<CustomersCommand> _logger;
        private readonly ICustomersFactory _factory;
        public CustomersCommand (
            IInventoryDatabaseService database,
            ICustomersFactory factory,
            ILogger<CustomersCommand> logger
        ) {
            _factory = factory;
            _database = database;
            _logger = logger;
        }

        public CustomerViewModel Create (NewCustomerModel newCustomer) {
            try {
                var customer = _factory.CustomerForCreation (newCustomer);
                _database.Customer.Add (customer);
                _database.Save ();
                return _factory.CustomerForView (customer);

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);

                return null;
            }

        }
        public bool Delete (Customer deletedCustomer) {

            try {

                _database.Customer.Remove (deletedCustomer);
                _database.Save ();
                return true;

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);
                return false;
            }

        }
        public bool Update (Customer oldCustomer, UpdatedCustomerModel updatedCustomer) {

            try {

                var customer = _factory.CustomerForUpdate (oldCustomer, updatedCustomer);
                _database.Customer.Update (customer).State = EntityState.Modified;
                _database.Save ();
                return true;

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);
                return false;
            }

        }
    }
}