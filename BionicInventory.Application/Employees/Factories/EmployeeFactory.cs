using BionicInventory.Application.Employees.Interfaces;
using BionicInventory.Application.Employees.Models;
using BionicInventory.Domain.Employees;

namespace BionicInventory.Application.Employees.Factories {
    public class EmployeesFactory : IEmployeesFactory {
        public Employee EmployeeForInsert (EmployeeDto updateData) {

            var employee = new Employee ();

            employee.FirstName = updateData.FirstName;
            employee.LastName = updateData.LastName;

            return employee;
        }

        public Employee EmployeeForUpdate (Employee oldEmployee, EmployeeDto updateData) {


            oldEmployee.FirstName = updateData.FirstName;
            oldEmployee.LastName = updateData.LastName;

            return oldEmployee;
        }

        public EmployeeViewModel EmployeeForView (Employee employee) {

            var employeeView = new EmployeeViewModel ();
            employeeView.id = employee.Id;
            employeeView.firstName = employee.FirstName;
            employeeView.lastName = employee.LastName;
            employeeView.dateAdded = employee.DateAdded;
            employeeView.dateUpdated = employee.DateUpdated;

            return employeeView;
        }
    }
}