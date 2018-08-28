using System.Collections.Generic;
using BionicInventory.Application.Employees.Interfaces;
using BionicInventory.Domain.Employees;

namespace BionicInventory.Application.Employees.Queries {
    public class EmployeesQuery : IEmployeesQuery {
        public IEnumerable<Employee> GetAll () {
            throw new System.NotImplementedException ();
        }

        public Employee GetById (uint id) {
            throw new System.NotImplementedException ();
        }
    }
}