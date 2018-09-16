/*
 * @CreateTime: Sep 15, 2018 11:44 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 15, 2018 11:44 PM
 * @Description: Modify Here, Please 
 */
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