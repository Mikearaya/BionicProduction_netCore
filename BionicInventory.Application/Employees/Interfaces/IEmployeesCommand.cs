using BionicInventory.Application.Employees.Models;
using BionicInventory.Application.Interfaces;
using BionicInventory.Domain.Employees;

namespace BionicInventory.Application.Employees.Interfaces {
    public interface IEmployeesCommand {

        EmployeeViewModel AddEmployee (NewEmployeeDto newEmployee);
        bool UpdateEmployee (Employee oldEmployee, UpdatedEmployeeDto updatedEmployee);
        bool DeleteEmployee (Employee employee);

    }
}