/*
 * @CreateTime: Sep 26, 2018 8:05 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 22, 2018 3:10 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Application.Customers.Interfaces.Query;
using BionicInventory.Application.Employees.Interfaces;
using BionicInventory.Application.Products.Interfaces;
using BionicInventory.Application.SalesOrders.Interfaces;
using BionicInventory.Application.SalesOrders.Models;
using BionicInventory.Application.SalesOrders.Models.ReportModels;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using BionicInventory.Domain.CustomerOrders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BionicInventory.API.Controllers.SalesOrders {

    [InventoryAPI ("salesorders")]
    public class SalesOrderController : Controller {
        private readonly ISalesOrderFactory _factory;
        private readonly ISalesOrderCommand _command;
        private readonly ISalesOrderQuery _query;
        private readonly ICustomersQuery _customerQuery;
        private readonly IProductsQuery _itemQuery;
        private readonly IEmployeesQuery _employeeQuery;
        private readonly ISalesOrderReportQuery _salesReportQuery;

        public SalesOrderController (ISalesOrderFactory factory,
            ISalesOrderQuery query,
            ISalesOrderCommand command,
            ILogger<SalesOrderController> logger,
            ICustomersQuery customerQuery,
            IEmployeesQuery employeeQuery,
            IProductsQuery productQuery,
            ISalesOrderReportQuery salesReportQuery) {

            _factory = factory;
            _command = command;
            _query = query;
            _customerQuery = customerQuery;
            _itemQuery = productQuery;
            _employeeQuery = employeeQuery;
            _salesReportQuery = salesReportQuery;
        }

        [HttpGet ()]
        [ProducesResponseType (200, Type = typeof (IEnumerable<CustomerOrdersView>))]
        [ProducesResponseType (500)]
        public IActionResult GetAllSalesOrders (int pageNumber = 1, int pageSize = 10) {
            var salesOrders = _query.GetAllCustomerOrders ();
            return StatusCode (200, salesOrders);
        }

        [HttpGet ("{id}")]
        [ProducesResponseType (200, Type = typeof (CustomerOrder))]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult GetSalesOrderById (uint id, string type = "VIEW") {

            if (id == 0) {
                return StatusCode (400, "Invelid Customer Id");
            }
            Object result;
            if (type.ToUpper () == "RAW") {
                result = _query.GetSalesOrderById (id);
            } else {
                result = _query.GetCustomerOrderDetail (id);
            }

            if (result == null) {
                return StatusCode (404);
            }

            return StatusCode (200, result);
        }

        [HttpPost (Name = "CreateSalesOrder")]
        [ProducesResponseType (201, Type = typeof (CustomerOrder))]
        [ProducesResponseType (400)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public IActionResult CreateSalesOrder ([FromBody] NewSalesOrderDto newOrder) {

            if (newOrder == null) {
                return StatusCode (400);
            }

            if (!ModelState.IsValid) {
                return new InvalidInputResponse (ModelState);
            }

            var client = _customerQuery.GetCustomerById (newOrder.ClientId);

            if (client == null) {
                ModelState.AddModelError ("ClientId", $"Customer with id: {newOrder.ClientId} Not Found");
            }

            var employee = _employeeQuery.GetEmployeeById (newOrder.CreatedBy);

            if (employee == null) {
                ModelState.AddModelError ("CreatedBy", $"Employee with id: {newOrder.CreatedBy} Not Found");
            }

            foreach (var orderDetail in newOrder.purchaseOrderDetail) {
                var product = _itemQuery.GetProductById (orderDetail.ItemId);
                if (product == null) {
                    ModelState.AddModelError ("ItemId", $"Product With id: {orderDetail.ItemId} Not Found");
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

            }
            var salesOrder = _factory.CreateNewSaleOrder (newOrder);

            var result = _command.CreateSalesOrder (salesOrder);
            if (result == null) {
                return StatusCode (500);
            }

            return StatusCode (201, result);

        }

        [HttpPut ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public ActionResult UpdateCustomerOrderStatus (uint id, [FromBody] StatusUpdateDto newStatus) {
            if (newStatus == null) {
                return StatusCode (400);
            }

            if (!ModelState.IsValid) {
                return new InvalidInputResponse (ModelState);
            }

            var customerOrder = _query.GetSalesOrderById (id);
            if (customerOrder == null) {
                return StatusCode (404, $"Customer Order With id: {id} Not Found");
            }

            customerOrder.OrderStatus = newStatus.Status;
            var updateResult = _command.UpdateSalesOrder (customerOrder);

            if (updateResult == false) {
                return StatusCode (500, "Unknown error Occured please try again later");
            }
            return StatusCode (204);
        }

        [HttpGet ("reports")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (500)]
        public ActionResult<MonthlySalesReportModel> GetSalesReport (string type = "YEARLY") {
            object reportObj = null;
            switch (type.ToUpper ()) {
                case "YEARLY":
                    reportObj = _salesReportQuery.GetYearlySalesReport ();
                    break;

            }

            if (reportObj == null) {
                return StatusCode (500, "Unknown Error Occured");
            }

            return StatusCode (200, reportObj);

        }

        [HttpDelete ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public ActionResult DeleteCustomerOrder (uint id) {

            var customerOrder = _query.GetSalesOrderById (id);

            if (customerOrder == null) {
                return StatusCode (404);
            }

            var result = _command.DeleteSalesOrders (customerOrder);

            if (result == false) {
                return StatusCode (500, "Unknown Error occured while deleting customer order");
            }

            return StatusCode (204);
        }

    }
}