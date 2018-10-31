/*
 * @CreateTime: Sep 15, 2018 11:48 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 15, 2018 11:48 PM
 * @Description: Employees Factory Class
 */
using System;
using BionicInventory.Application.Employees.Interfaces;
using BionicInventory.Application.Employees.Models;
using BionicInventory.Domain.Employees;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Employees.Factories {
    public class EmployeesFactory : IEmployeesFactory {
        private readonly ILogger<EmployeesFactory> _logger;

        public EmployeesFactory (ILogger<EmployeesFactory> logger) {
            _logger = logger;
        }
        public Employee EmployeeForInsert (NewEmployeeDto updateData) {

            try {

                var employee = new Employee ();

                employee.FirstName = updateData.FirstName;
                employee.LastName = updateData.LastName;

                return employee;

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);
                return null;
            }
        }

        public Employee EmployeeForUpdate (Employee oldEmployee, UpdatedEmployeeDto updateData) {

            try {

                oldEmployee.FirstName = updateData.FirstName;
                oldEmployee.LastName = updateData.LastName;

                return oldEmployee;

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);
                return null;
            }
        }

        public EmployeeViewModel EmployeeForView (Employee employee) {

            try {

                var employeeView = new EmployeeViewModel ();
                employeeView.id = employee.Id;
                employeeView.firstName = employee.FirstName;
                employeeView.lastName = employee.LastName;
                employeeView.dateAdded = employee.DateAdded;
                employeeView.dateUpdated = employee.DateUpdated;

                return employeeView;

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);
                return null;
            }
        }
    }
}