using System.Collections.Generic;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Employees.Interfaces;
using BionicInventory.Domain.Employees;

namespace BionicInventory.Application.Employees.Queries {
    public class EmployeesQuery : IEmployeesQuery {

        public IInventoryDatabaseService _database { get; }

        public EmployeesQuery (IInventoryDatabaseService database) {
            _database = database;
        }

        public IEnumerable<Employee> GetAllEmployees () {
            return _database.Employee.ToList ();
        }
        public Employee GetEmployeeById (uint id) {
            return _database.Employee.Find (id);
        }
    }
}