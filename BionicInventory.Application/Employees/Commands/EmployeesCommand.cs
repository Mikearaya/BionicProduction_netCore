/*
 * @CreateTime: Sep 15, 2018 11:44 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 15, 2018 11:45 PM
 * @Description: Modify Here, Please 
 */
using System;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Employees.Interfaces;
using BionicInventory.Application.Employees.Models;
using BionicInventory.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Employees.Commands {
    public class EmployeesCommand : IEmployeesCommand {

        private readonly IInventoryDatabaseService _database;
        private readonly IEmployeesFactory _factory;
        private readonly ILogger<EmployeesCommand> _logger;

        public EmployeesCommand (IInventoryDatabaseService database,
            IEmployeesFactory factory,
            ILogger<EmployeesCommand> logger) {
            _database = database;
            _factory = factory;
            _logger = logger;
        }

        public EmployeeViewModel AddEmployee (NewEmployeeDto newEmployee) {

            try {

                var employee = _factory.EmployeeForInsert (newEmployee);
                _database.Employee.Add (employee);
                _database.Save ();

                return _factory.EmployeeForView (employee);

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);
                return null;
            }

        }

        public bool DeleteEmployee (Employee employee) {

            try {

                _database.Employee.Remove (employee);
                _database.Save ();

                return true;

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);
                return false;
            }
        }
        public bool UpdateEmployee (Employee oldEmployee, UpdatedEmployeeDto updatedEmployee) {

            try {

                var employee = _factory.EmployeeForUpdate (oldEmployee, updatedEmployee);
                _database.Employee.Add (employee).State = EntityState.Modified;
                _database.Save ();

                return true;

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);
                return false;
            }
        }
    }
}