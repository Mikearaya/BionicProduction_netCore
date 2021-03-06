/*
 * @CreateTime: Sep 8, 2018 2:14 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 23, 2018 11:41 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using BionicInventory.Application.Customers.Interfaces;
using BionicInventory.Application.Customers.Interfaces.Query;
using BionicInventory.Application.Customers.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using BionicInventory.Domain.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BionicInventory.API.Controllers.Customers {

    [InventoryAPI ("customers")]
    [DisplayName ("Customers")]
    [Authorize]
    public class CustomersController : Controller {
        private readonly ICustomersQuery _query;
        private readonly ICustomersCommand _command;
        private readonly ICustomersFactory _factory;

        private readonly IResponseFormatFactory _responseFactory;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController (
            ICustomersQuery customersquery,
            ICustomersCommand customerCommand,
            ICustomersFactory customerFactory,
            IResponseFormatFactory responseFactory,
            ILogger<CustomersController> logger
        ) {
            _query = customersquery;
            _command = customerCommand;
            _factory = customerFactory;
            _responseFactory = responseFactory;
            _logger = logger;
        }

        [HttpGet]
        [DisplayName ("View Customers List")]
        [Authorize]
        [ProducesResponseType (200)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (500)]
        public ActionResult<IEnumerable<CustomerViewModel>> GetAllCustomers () {

            var data = _query.GetCustomerView ();

            return StatusCode (200, data);
        }

        [HttpGet ("{id}")]
        [DisplayName ("View Customer Detail")]
        [Authorize]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public ActionResult<CustomerViewModel> GetCustomer (uint id) {
            if (id == 0) {
                return StatusCode (400);
            }

            var customer = _query.GetCustomerViewById (id);

            if (customer != null) {
                return StatusCode (200, customer);
            }

            return NotFound ();

        }

        [HttpPost]
        [DisplayName ("Create Customer")]
        [Authorize]
        [ProducesResponseType (201)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public ActionResult<CustomerViewModel> AddNewCustomer ([FromBody] NewCustomerDto data) {
            try {
                if (data == null) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }
                var customer = _command.Create (data);

                if (customer != null) {
                    return StatusCode (201, customer);
                } else {
                    return StatusCode (500, "Something Went Wrong please try again later");
                }

            } catch (DuplicateTinNumberException tinDuplicate) {
                ModelState.AddModelError ("TIN No", tinDuplicate.Message);
                return new InvalidInputResponse (ModelState);

            } catch (DuplicatePhonenumberException phoneDuplicate) {
                ModelState.AddModelError ("Telephone", phoneDuplicate.Message);
                return new InvalidInputResponse (ModelState);

                } catch (Exception e) {
                _logger.LogError (500, e.StackTrace, e.Message);
                return StatusCode (500, e.Message);
            }

        }

        [HttpPut ("{id}")]
        [DisplayName ("Update Customer")]
        [Authorize]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public ActionResult UpdateCustomerRecord (uint id, [FromBody] UpdatedCustomerDto updatedData) {

            try {
                if (updatedData == null) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                var customer = _query.GetCustomerById (id);

                if (customer == null) {
                    return StatusCode (404, $"Customer with id: {id} Not Found ");
                }

                var customerFactory = _factory.CustomerForUpdate (updatedData);
                var result = _command.UpdateCustomerData (customerFactory);
                if (result == true) {
                    return StatusCode (204);
                } else {
                    return StatusCode (500, "Something Wrong Happened Try Again");
                }

            } catch (DuplicatePhonenumberException e) {
                ModelState.AddModelError ("Duplicate Phone", e.Message);
                return new InvalidInputResponse (ModelState);

                } catch (Exception e) {
                _logger.LogError (500, e.StackTrace, e.Message);
                return StatusCode (500, "Unknown error occured");
            }

        }

        [HttpDelete ("{id}")]
        [DisplayName ("Delete Customer")]
        [Authorize]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public ActionResult DeleteSingleCustomer (uint id) {

            try {

                if (id == 0) {
                    return StatusCode (400);
                }
                var customer = _query.GetCustomerById (id);

                if (customer == null) {
                    return StatusCode (404, $"Customer with id: {id} Not Found !!!");
                }

                if (_command.Delete (customer)) {
                    return StatusCode (204);
                }

                return StatusCode (500, "Something Wrong Happened Try Again");

            } catch (Exception e) {
                _logger.LogError (500, e.StackTrace, e.Message);
                return StatusCode (500, e.Message);
            }

        }

        [HttpDelete ("{customerId}/address/{id}")]
        [DisplayName ("Delete Customer Address")]
        [Authorize]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public ActionResult DeleteCustomerAddress (uint customerId, uint id) {

            if (customerId == 0 || id == 0) {
                return StatusCode (400);
            }

            var address = _query.GetCustomerAddress (customerId, id);

            if (address == null) {
                return StatusCode (404, $"Customer address with id: {id} Not Found!!!");
            }

            var result = _command.DeleteCustomerAddress (address);

            if (result == false) {
                return StatusCode (500);
            }

            return StatusCode (204);
        }

        [HttpDelete ("{customerId}/socialMedia/{id}")]
        [DisplayName ("Delete Customer Social Media")]
        [Authorize]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public ActionResult DeleteCustomerSocialMediaAddress (uint customerId, uint id) {

            if (customerId == 0 || id == 0) {
                return StatusCode (400);
            }

            var socialAddress = _query.GetCustomerSocialAddress (customerId, id);

            if (socialAddress == null) {
                return StatusCode (404, $"Customer social media address with id: {id} Not Found!!!");
            }

            var result = _command.DeleteCustomerSocialAddress (socialAddress);

            if (result == false) {
                return StatusCode (500);
            }

            return StatusCode (204);
        }

        [HttpDelete ("{customerId}/phonenumber/{id}")]
        [DisplayName ("Delete Customer Phonenumber")]
        [Authorize]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public ActionResult DeleteCustomerPhoneNumber (uint customerId, uint id) {

            if (customerId == 0 || id == 0) {
                return StatusCode (400);
            }

            var phoneNumber = _query.GetCustomerPhone (customerId, id);

            if (phoneNumber == null) {
                return StatusCode (404, $"Customer Phone Number with id: {id} Not Found!!!");
            }

            var result = _command.DeleteCustomerPhone (phoneNumber);

            if (result == false) {
                return StatusCode (500);
            }

            return StatusCode (204);
        }

    }

}