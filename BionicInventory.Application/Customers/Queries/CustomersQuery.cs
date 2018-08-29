using System.Collections.Generic;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Customers.Interfaces.Query;
using BionicInventory.Domain.Customers;

namespace BionicInventory.Application.Customers.Queries
{
    public class CustomersQuery : ICustomersQuery
    {
        private readonly IInventoryDatabaseService _database;
        public CustomersQuery(IInventoryDatabaseService database) {
            _database = database;
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _database.Customer.ToList();
        }

        public Customer GetCustomerById(uint customerId)
        {
            return _database.Customer.Find(customerId);
        }
    }
}