using BionicInventory.Application.Employees.Models;
using BionicInventory.Domain.Employees;

namespace BionicInventory.Application.Employees.Interfaces {
    public interface IEmployeesFactory {
        EmployeeViewModel EmployeeForView (Employee employee);
        Employee EmployeeForUpdate (Employee oldEmployee, EmployeeDto updateData);
        Employee EmployeeForInsert (EmployeeDto updateData);

    }
}