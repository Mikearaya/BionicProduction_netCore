/*
 * @CreateTime: Nov 16, 2018 8:36 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 18, 2018 8:28 PM
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
using BionicInventory.Application.Shipments.Models.ViewModels;

namespace BionicInventory.API.Controllers.Products.Shipments {
    [InventoryAPI ("shipments")]
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

        [HttpGet]
        public ActionResult GetAllShipments () {
            Object shipments = _query.GetAllShipmentStatus ();

            return StatusCode (200, shipments);
        }

        [HttpGet ("{id}")]
        public ActionResult GetShipmentById (uint id) {

            Object shipment = _query.GetShipmentDetails (id);
            if (shipment == null) {
                return StatusCode (404);
            }

            return StatusCode (200, shipment);
        }

        [HttpGet ("salesorders/{customerOrderId}")]
        public ActionResult GetCustomerOrderShipmentSummary (uint customerOrderId, string type = "DETAIL") {
            Object shipments;

            var customerOrder = _customerOrderQuery.GetSalesOrderById (customerOrderId);

            if (customerOrder == null) {
                return StatusCode (404, $"Customer Order with id {customerOrderId} Not Found!!!");
            }

            switch (type.ToUpper ()) {
                case "DETAIL":
                    shipments = _query.GetCustomerOrderShipmentStatus (customerOrderId);
                    return StatusCode (200, shipments);
                case "SUMMARY":
                    shipments = _query.GetCustomerOrderShipmentsSummary (customerOrderId);
                    return StatusCode (200, shipments);
            }

            return StatusCode (500, "Request Not Identified");

        }

        [HttpPost ("salesorders/{customerOrderId}")]
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
            if (shipment == null) {
                ModelState.AddModelError ("Quantity", "Unable to Complete Shipment that exceed  the  available stock item Quantity");
                return new InvalidInputResponse (ModelState);
            }
            var shipmentResult = _command.CreateShipment (shipment);
            if (shipmentResult == null) {
                return StatusCode (500);
            }

            var shipmentView = _query.GetShipmentDetails (shipmentResult.Id);

            return StatusCode (201, shipmentView);

        }

        [HttpPut("pickings/{shipmentId}")]
        public ActionResult PickShipmentItems(uint shipmentId) {
            var shipment = _query.GetShipmentById(shipmentId);

            if(shipment == null) {
                return StatusCode(404, $"Shipment with id: {shipmentId} not found");
            }

            var pickingResult = _command.PickShipment(shipment);

            if(pickingResult == null) {
                return StatusCode(500, "Unknown error occured please try again later");
            }

            return StatusCode(201, shipment);
        }

    }
}