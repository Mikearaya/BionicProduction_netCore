/*
 * @CreateTime: Oct 26, 2018 11:21 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 27, 2018 12:05 AM
 * @Description: Modify Here, Please 
 */


using System;
using System.Collections.Generic;
using BionicInventory.API.Commons;
using BionicInventory.Application.Invoices.Interfaces;
using BionicInventory.Application.Invoices.Models;
using BionicInventory.Application.SalesOrders.Interfaces;
using BionicInventory.Commons;
using BionicInventory.Domain.Invoices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BionicInventory.API.Controllers.Invoices {
    [InventoryAPI ("salesorders")]
    public class InvoicesController : Controller {
        private readonly IInvoicesCommand _command;
        private readonly IInvoicesQuery _query;
        private readonly IInvoiceFactory _factory;
        private readonly ISalesOrderQuery _customerOrderQuery;
        private readonly ILogger<InvoicesController> _logger;

        public InvoicesController(IInvoicesCommand command,
                                    IInvoicesQuery query,
                                    IInvoiceFactory factory,
                                    ISalesOrderQuery customerOrderQuery,
                                    ILogger<InvoicesController> logger) {
                                        _command =command;
                                        _query = query;
                                        _factory = factory;
                                        _customerOrderQuery = customerOrderQuery;
                                        _logger = logger;
        }


        [HttpGet("invoices/{id}")]
        [ProducesResponseType(200, Type = typeof(Invoice))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public  IActionResult GetInvoiceById(uint id, string type = "VIEW") {

            Object invoice;

                if(id == 0) {
                    return StatusCode(400);
                }
                
                if(type.ToUpper() == "SUMMARY") {
                    invoice = _query.GetCustomerOrderInvoiceStatus(id);
                } else {
                    invoice = _query.GetInvoiceDetailView (id);
                }

                if(invoice == null) {
                    return StatusCode(404);
                }

                return StatusCode(200, invoice);
        }

        [HttpGet("{customerOrderId}/invoices")]
        [ProducesResponseType(200, Type = typeof(Invoice))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public  IActionResult GetCustomerOrderInvoiceById(uint customerOrderId, string type = "VIEW") {

                Object invoice;
                
                if(customerOrderId == 0) {
                    return StatusCode(400);
                }
                if(type.ToUpper() == "SUMMARY") {
                    invoice = _query.GetCustomerOrderInvoiceStatus(customerOrderId);
                } else {
                invoice = _query.GetCustomerOrderInvoice(customerOrderId);
                }

                if(invoice == null) {
                    return StatusCode(404);
                }

                return StatusCode(200, invoice);
        }

        [HttpGet("invoices")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Invoice>))]
        [ProducesResponseType(500)]
        public  IActionResult GetInvoices(string type = "VIEW") {

            Object invoices;

            if(type.ToUpper() == "SUMMARY") {
                invoices = _query.GetCustomerOrderInvoiceStatus();
            } else {
                invoices = _query.GetAllInvoices();
            }
            return StatusCode(200, invoices);
        }


        [HttpPost("{customerOrderId}/invoices")]
        [ProducesResponseType(201, Type = typeof(Invoice))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult CreateNewInvoice(uint customerOrderId, [FromBody] NewInvoiceDto invoice) {
            
                if(invoice == null || customerOrderId == 0) {
                    return StatusCode(400);
                }

                if(!ModelState.IsValid) {
                    return new InvalidInputResponse(ModelState);
                }

                var customerOrder = _customerOrderQuery.GetSalesOrderById(customerOrderId);

                if(customerOrder == null) {
                    return StatusCode(404, $"Customer Order With id: {customerOrderId} Not Found ");
                }

                var newInvoice = _factory.NewInvoice(invoice);

                var result = _command.CreateInvoice(newInvoice);

                if(result == null) {
                    return StatusCode(500, $"Unknown Error Occured While Saving Invoice Try Again");
                }

                return StatusCode(201, result);
        }


        
    }
}