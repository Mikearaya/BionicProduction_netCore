using System;
using System.Collections.Generic;
using BionicInventory.Application.Employees.Interfaces;
using BionicInventory.Application.Employees.Models;
using BionicInventory.Commons;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.Employees {

    [InventoryAPI ("employees")]
    public class EmployeesController : Controller {

        private readonly IEmployeesCommand _command;
        private readonly IEmployeesQuery _query;
        private readonly IEmployeesFactory _factory;

        public EmployeesController (
            IEmployeesCommand command,
            IEmployeesQuery query,
            IEmployeesFactory factory
        ) {
            _command = command;
            _query = query;
            _factory = factory;
        }

        [HttpGet ("{id}")]
        [ProducesResponseType (200, Type = typeof (EmployeeViewModel))]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public IActionResult GetEmployeeById (uint id) {

            if (ModelState.IsValid && id != 0) {

                try {
                    var employee = _query.GetEmployeeById (id);

                    if (employee != null) {
                        var employeeView = _factory.EmployeeForView (employee);
                        return StatusCode (200, employeeView);
                    } else {
                        return StatusCode (404);
                    }
                } catch (Exception) {
                    return StatusCode (500, "Unkown Error Occured while processing Request, Try Again");
                }

            } else {
                return StatusCode (422, "Invalid Parameter For Employee Id");
            }

        }

        [HttpGet]
        [ProducesResponseType (200, Type = typeof (EmployeeViewModel))]
        [ProducesResponseType (500)]
        public IActionResult GetAllEmployees () {

            try {

                var employees = _query.GetAllEmployees ();
                List<EmployeeViewModel> employeesList = new List<EmployeeViewModel> ();

                foreach (var employee in employees) {
                    employeesList.Add (_factory.EmployeeForView (employee));
                }

                return StatusCode (200, employeesList);

            } catch (System.Exception) {

                return StatusCode (500, "Unkown Error Occured while processing Request, Try Again");
            }
        }

        [HttpPost]
        [ProducesResponseType (201, Type = typeof (EmployeeViewModel))]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public IActionResult AddEmploeeRecord ([FromBody] EmployeeDto newEmployee) {

            if (ModelState.IsValid && newEmployee != null) {

                try {
                    var employee = _command.AddEmployee (newEmployee);
                    if (employee != null) {
                        return StatusCode (201, employee);
                    } else {
                        return StatusCode (422, "One or more required fields missing for employee");
                    }

                } catch (System.Exception) {
                    return StatusCode (500, "Unkown Error Occured while processing Request, Try Again");
                }
            } else {
                return StatusCode (422, "One or more required fields missing for employee");
            }
        }

        [HttpPut]
        [ProducesResponseType (204)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public IActionResult UpdateEmployeeRecord ([FromBody] EmployeeDto updatedData) {

            if (ModelState.IsValid && updatedData != null) {

                var employee = _query.GetEmployeeById (updatedData.id);

                if (employee != null) {

                    if (_command.UpdateEmployee (employee, updatedData)) {
                        return StatusCode (204);
                    } else {
                        return StatusCode (500, "Unkown Error Occured while processing Request, Try Again");
                    }

                } else {
                    return StatusCode (404);
                }

            } else {
                return StatusCode (422, "One or more required fields missing for employee");
            }

        }

        [HttpPut ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public IActionResult UpdateEmployeeRecord (uint id, [FromBody] EmployeeDto updatedData) {

            if (ModelState.IsValid && updatedData != null) {

                var employee = _query.GetEmployeeById (id);
                if (employee != null) {

                    if (_command.UpdateEmployee (employee, updatedData)) {
                        return StatusCode (204);
                    } else {
                        return StatusCode (500, "Unkown Error Occured while processing Request, Try Again");
                    }

                } else {
                    return StatusCode (404);
                }

            } else {
                return StatusCode (422, "One or more required fields missing for employee");
            }

        }

        [HttpDelete ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult DeleteSingleEmployeeRecord (uint id) {

            try {
                var employee = _query.GetEmployeeById (id);

                if (employee != null) {

                    if (_command.DeleteEmployee (employee)) {
                        return StatusCode (204);
                    } else {
                        return StatusCode (422);
                    }

                } else {

                    return StatusCode (404);
                }
            } catch (Exception) {

                return StatusCode (500, "Unkown Error Occured while processing Request, Try Again");
            }

        }

    }
}