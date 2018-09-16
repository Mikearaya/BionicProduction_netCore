/*
 * @CreateTime: Sep 8, 2018 2:14 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 8, 2018 2:38 AM
 * @Description: Modify Here, Please 
 */
using System.Collections;
using System.Collections.Generic;
using BionicInventory.Application.Customers.Interfaces;
using BionicInventory.Application.Customers.Interfaces.Query;
using BionicInventory.Application.Customers.Models;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using BionicInventory.Domain.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace BionicInventory.API.Controllers.Customers {


    [InventoryAPI ("customers")]
    [Authorize]
    public class CustomersController : Controller {
        private readonly ICustomersQuery _query;
        private readonly ICustomersCommand _command;
        private readonly ICustomersFactory _factory;

        private readonly IResponseFormatFactory _responseFactory;

        public CustomersController (
            ICustomersQuery customersquery,
            ICustomersCommand customerCommand,
            ICustomersFactory customerFactory,
            IResponseFormatFactory responseFactory
        ) {
            _query = customersquery;
            _command = customerCommand;
            _factory = customerFactory;
            _responseFactory = responseFactory;
        }

        [HttpGet]
        [ProducesResponseType (200, Type = typeof (ResponseDataFormat))]
        public IActionResult GetAllCustomers () {

            var data = _query.GetAllCustomers ();

            var response = _responseFactory.DataForPresentation ((List<CustomerViewModel>) _factory.CustomerForView (data));
            return StatusCode (200, response);
        }

        [HttpOptions]
        [ProducesResponseType (200, Type = typeof (ResponseDataFormat))]
        public IActionResult GetAll () {

            var data = _query.GetAllCustomers ();

            var response = _responseFactory.DataForPresentation ((List<CustomerViewModel>) _factory.CustomerForView (data));
            return StatusCode (200, response);
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

        [HttpPut]
        [ProducesResponseType (204)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public IActionResult UpdateEmployeeRecord ([FromBody] UpdatedCustomerModel updatedData) {

            if (ModelState.IsValid && updatedData != null) {
                var customer = _query.GetCustomerById (updatedData.id);

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