/*
 * @CreateTime: Nov 16, 2018 8:36 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 16, 2018 8:37 PM
 * @Description: Modify Here, Please 
 */
using System;
using BionicInventory.Application.Employees.Interfaces;
using BionicInventory.Application.SalesOrders.Interfaces;
using BionicInventory.Application.Shipments.Interfaces;
using BionicInventory.Application.Shipments.Models;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BionicInventory.API.Controllers.Products.Shipments {
    [InventoryAPI ("products")]
    public class ShipmentsController : Controller {
        private readonly IShipmentQuery _query;
        private readonly IShipmentCommand _command;
        private readonly IShipmentFactory _factory;
        private readonly ILogger<ShipmentsController> _logger;
        private readonly ISalesOrderQuery _customerOrderQuery;
        private readonly IEmployeesQuery _employeeQuery;

        public ShipmentsController (
            IShipmentQuery query,
            IShipmentCommand command,
            IShipmentFactory factory,
            ISalesOrderQuery customerOrderQuery,
            ILogger<ShipmentsController> logger,
            IEmployeesQuery employeeQuery
        ) {
            _query = query;
            _command = command;
            _factory = factory;
            _logger = logger;
            _customerOrderQuery = customerOrderQuery;
            _employeeQuery = employeeQuery;
        }

        [HttpGet ("shipments")]
        public ActionResult GetAllCustomerOrderShipments () {
            Object shipments = _query.GetAllShipmentStatus ();

            return StatusCode (200, shipments);
        }

        [HttpGet ("shipments/salesorders/{customerOrderId}")]
        public ActionResult GetCustomerOrderShipmentSummary (uint customerOrderId) {
            Object shipments;
            var customerOrder = _customerOrderQuery.GetSalesOrderById (customerOrderId);

            if (customerOrder == null) {
                return StatusCode (404, $"Customer Order with id {customerOrderId} Not Found!!!");
            }
            shipments = _query.GetCustomerOrderShipmentStatus (customerOrderId);

            return StatusCode (200, shipments);

        }

        [HttpPost ("salesorders/{customerOrderId}/shipments")]
        public ActionResult CreateNewCustomerOrderShipment (uint customerOrderId, [FromBody] NewShipmentDto newShipment) {
            var customerOrder = _customerOrderQuery.GetSalesOrderById (customerOrderId);

            if (customerOrder == null) {
                return StatusCode (404, $"Customer Order with id {customerOrderId} Not Found!!!");
            }

            if (newShipment == null) {
                return StatusCode (400, "is null");
            }

            if (!ModelState.IsValid) {
                return new InvalidInputResponse (ModelState);
            }
            var shipment = _factory.CreateNewShipment (newShipment);

            var shipmentResult = _command.CreateShipment (shipment);
            if (shipmentResult == null) {
                return StatusCode (500);
            }

            return StatusCode (201, shipment);

        }

    }
}