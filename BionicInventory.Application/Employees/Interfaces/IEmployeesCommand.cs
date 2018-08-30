using BionicInventory.Application.Employees.Models;
using BionicInventory.Application.Interfaces;
using BionicInventory.Domain.Employees;

namespace BionicInventory.Application.Employees.Interfaces {
    public interface IEmployeesCommand {

        EmployeeViewModel AddEmployee (EmployeeDto newEmployee);
        bool UpdateEmployee (Employee oldEmployee, EmployeeDto updatedEmployee);
        bool DeleteEmployee (Employee employee);

    }
}