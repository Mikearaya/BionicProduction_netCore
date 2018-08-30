using System.Collections.Generic;
using BionicInventory.Application.Interfaces;
using BionicInventory.Domain.Employees;

namespace BionicInventory.Application.Employees.Interfaces {
    public interface IEmployeesQuery {
        Employee GetEmployeeById (uint id);
        IEnumerable<Employee> GetAllEmployees ();

    }
}