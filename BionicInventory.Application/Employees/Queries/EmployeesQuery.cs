/*
 * @CreateTime: Sep 15, 2018 11:43 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 15, 2018 11:43 PM
 * @Description: Employees Query Class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Employees.Interfaces;
using BionicInventory.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Employees.Queries {
    public class EmployeesQuery : IEmployeesQuery {

        public IInventoryDatabaseService _database { get; }

        private readonly ILogger<EmployeesQuery> _logger;

        public EmployeesQuery (IInventoryDatabaseService database,
            ILogger<EmployeesQuery> logger) {
            _database = database;
            _logger = logger;
        }

        public IEnumerable<Employee> GetAllEmployees () {

            try {

                return _database.Employee.AsNoTracking ().Select(employee => new Employee(){
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    DateAdded = employee.DateAdded,
                    DateUpdated = employee.DateUpdated
                }).ToList ();

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);
                return null;
            }
        }
        public Employee GetEmployeeById (uint id) {

            try {
                
                return _database.Employee.Select(employee => new Employee(){
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    DateAdded = employee.DateAdded,
                    DateUpdated = employee.DateUpdated
                }).FirstOrDefault(employee => employee.Id == id);

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);
                return null;
            }
        }
    }
}