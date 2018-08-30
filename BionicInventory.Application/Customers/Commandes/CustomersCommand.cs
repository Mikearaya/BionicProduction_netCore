using System;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Customers.Interfaces;
using BionicInventory.Application.Customers.Models;
using BionicInventory.Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Customers.Commands {
    public class CustomersCommand : ICustomersCommand {
        private readonly IInventoryDatabaseService _database;
        private readonly ICustomersFactory _factory;
        public CustomersCommand (
            IInventoryDatabaseService database,
            ICustomersFactory factory
        ) {
            _factory = factory;
            _database = database;
        }
        public CustomerViewModel Create (NewCustomerModel newCustomer) {
            try {
                var customer = _factory.CustomerForCreation (newCustomer);
                _database.Customer.Add (customer);
                _database.Save ();
                return _factory.CustomerForView (customer);
            } catch (DbUpdateException) {
                // Combine the original exception message with the new one.
                return null;
            } catch (Exception) {
                throw new Exception ();
            }

        }
        public bool Delete (Customer deletedCustomer) {
            
            try {

                _database.Customer.Remove (deletedCustomer);
                _database.Save ();
                return true;
            } catch (Exception) {
                return false;
            }

        }
        public bool Update (Customer oldCustomer, UpdatedCustomerModel updatedCustomer) {

            try {

                var customer = _factory.CustomerForUpdate (oldCustomer, updatedCustomer);
                _database.Customer.Add (customer).State = EntityState.Modified;
                _database.Save ();
                return true;
            } catch (Exception) {

                return false;
            }

        }
    }
}