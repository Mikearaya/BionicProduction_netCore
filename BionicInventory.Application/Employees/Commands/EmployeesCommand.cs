using System;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Employees.Interfaces;
using BionicInventory.Application.Employees.Models;
using BionicInventory.Domain.Employees;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Employees.Commands {
    public class EmployeesCommand : IEmployeesCommand {

        private readonly IInventoryDatabaseService _database;
        private readonly IEmployeesFactory _factory;
        public EmployeesCommand (IInventoryDatabaseService database,
            IEmployeesFactory factory) {
            _database = database;
            _factory = factory;
        }

        public EmployeeViewModel AddEmployee (NewEmployeeDto newEmployee) {

            try {

                var employee = _factory.EmployeeForInsert (newEmployee);
                _database.Employee.Add (employee);
                _database.Save ();

                return _factory.EmployeeForView (employee);

            } catch (Exception) {
                return null;
            }

        }

        public bool DeleteEmployee (Employee employee) {

            try {

                _database.Employee.Remove (employee);
                _database.Save ();

                return true;

            } catch (Exception) {
                return false;
            }
        }
        public bool UpdateEmployee (Employee oldEmployee, UpdatedEmployeeDto updatedEmployee) {

            try {

                var employee = _factory.EmployeeForUpdate (oldEmployee, updatedEmployee);
                _database.Employee.Add (employee).State = EntityState.Modified;
                _database.Save ();

                return true;

            } catch (Exception) {
                return false;
            }
        }
    }
}