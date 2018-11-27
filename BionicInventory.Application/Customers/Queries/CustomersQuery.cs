/*
 * @CreateTime: Sep 15, 2018 11:30 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 27, 2018 4:10 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Customers.Interfaces.Query;
using BionicInventory.Application.Customers.Models;
using BionicInventory.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Customers.Queries {
    public class CustomersQuery : ICustomersQuery {
        private readonly IInventoryDatabaseService _database;
        private readonly ILogger<CustomersQuery> _logger;

        public CustomersQuery (IInventoryDatabaseService database,
            ILogger<CustomersQuery> logger) {
            _database = database;
            _logger = logger;
        }
        public IList<Customer> GetAllCustomers () {

            try {

                return _database.Customer.ToList ();

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);
                return null;
            }
        }

        public Customer GetCustomerById (uint customerId) {

            try {

                return _database.Customer.Find (customerId);

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);
                return null;
            }
        }

        List<CustomerViewModel> ICustomersQuery.GetCustomerView () {

            return _database.Customer.Select (cus => new CustomerViewModel () {
                id = cus.Id,
                    fullName = cus.FullName,
                    email = cus.Email,
                    type = cus.Type,
                    tin = cus.Tin,
                    DateAdded = cus.DateAdded,
                    DateUpdated = cus.DateUpdated

            }).ToList ();
        }

    }
}