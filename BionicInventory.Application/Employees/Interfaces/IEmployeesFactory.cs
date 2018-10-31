/*
 * @CreateTime: Sep 15, 2018 11:44 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 15, 2018 11:44 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Employees.Models;
using BionicInventory.Domain.Employees;

namespace BionicInventory.Application.Employees.Interfaces {
    public interface IEmployeesFactory {
        EmployeeViewModel EmployeeForView (Employee employee);
        Employee EmployeeForUpdate (Employee oldEmployee, UpdatedEmployeeDto updateData);
        Employee EmployeeForInsert (NewEmployeeDto updateData);

    }
}