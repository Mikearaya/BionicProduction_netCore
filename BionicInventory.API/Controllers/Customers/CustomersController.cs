using BionicInventory.Application.Customers.Interfaces;
using BionicInventory.Application.Customers.Interfaces.Query;
using BionicInventory.Application.Customers.Models;
using BionicInventory.Commons;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.Customers {
    [InventoryAPI ("customers")]
    public class CustomersController : Controller {
        private readonly ICustomersQuery _query;
        private readonly ICustomersCommand _command;
        private readonly ICustomersFactory _factory;

        public CustomersController (
            ICustomersQuery customersquery,
            ICustomersCommand customerCommand,
            ICustomersFactory customerFactory
        ) {
            _query = customersquery;
            _command = customerCommand;
            _factory = customerFactory;
        }

        [HttpGet]
        [ProducesResponseType (200, Type = typeof (CustomerViewModel))]
        public IActionResult GetAllCustomers () {
            var x = _query.GetAllCustomers ();
            return Ok (x);
        }

        [HttpGet ("{id}")]
        [ProducesResponseType (200, Type = typeof (CustomerViewModel))]
        [ProducesResponseType (404)]
        public IActionResult GetCustomer (uint id) {
            if (ModelState.IsValid) {

                var customer = _query.GetCustomerById (id);

                if (customer != null) {
                    return Ok (customer);
                } else {
                    return NotFound ();
                }

            } else {
                return StatusCode (422);
            }

        }

        [HttpPost]
        [ProducesResponseType (201, Type = typeof (CustomerViewModel))]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public IActionResult AddNewCustomer ([FromBody] NewCustomerModel data) {

            if (ModelState.IsValid && data != null) {
                var customer = _command.Create (data);

                if (customer != null) {
                    return StatusCode (201, customer);
                } else {
                    return StatusCode (500, "Something Wrong Happened Try Again");
                }
            } else {
                return StatusCode (422, "One Or More Required Fields Missing, Try Again after correcting them");
            }

        }

        [HttpPut ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public IActionResult UpdateEmployeeRecord (uint id, [FromBody] UpdatedCustomerModel updatedData) {

            if (ModelState.IsValid && updatedData != null) {
                var customer = _query.GetCustomerById (id);

                if (customer != null) {
                    if (_command.Update (customer, updatedData)) {
                        return StatusCode (204);
                    } else {
                        return StatusCode (500, "Something Wrong Happened Try Again");
                    }
                } else {
                    return StatusCode (404);
                }
            } else {
                return StatusCode (422, "One Or More Required Fields Missing, Try Again after correcting them");
            }

        }

        [HttpDelete ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult DeleteSingleCustomer (uint id) {

            if (ModelState.IsValid && id != 0) {
                var customer = _query.GetCustomerById (id);

                if (customer != null) {

                    if (_command.Delete (customer)) {
                        return StatusCode (204);
                    } else {
                        return StatusCode (500, "Something Wrong Happened Try Again");
                    }
                } else {
                    return StatusCode (404);
                }

            } else {
                return StatusCode (422, "Customer Id Not Found to complete the delete operation");
            }

        }

    }
}