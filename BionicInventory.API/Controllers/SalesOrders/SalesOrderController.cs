/*
 * @CreateTime: Sep 26, 2018 8:05 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 26, 2018 10:49 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Customers.Interfaces.Query;
using BionicInventory.Application.Employees.Interfaces;
using BionicInventory.Application.Products.Interfaces;
using BionicInventory.Application.SalesOrders.Interfaces;
using BionicInventory.Application.SalesOrders.Models;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using BionicInventory.Domain.PurchaseOrders;
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

        public SalesOrderController (ISalesOrderFactory factory,
            ISalesOrderQuery query,
            ISalesOrderCommand command,
            ILogger<SalesOrderController> logger,
            ICustomersQuery customerQuery,
            IEmployeesQuery employeeQuery,
            IProductsQuery productQuery) {

            _factory = factory;
            _command = command;
            _query = query;
            _customerQuery = customerQuery;
            _itemQuery = productQuery;
            _employeeQuery = employeeQuery;
        }

        [HttpGet]
        [ProducesResponseType (200, Type = typeof (IEnumerable<SalesOrderView>))]
        [ProducesResponseType (500)]
        public IActionResult GetAllSalesOrders () {
            var salesOrders = _query.GetAllSalesOrders ();
            return StatusCode (200, salesOrders);
        }

        [HttpGet ("{id}")]
        [ProducesResponseType (200, Type = typeof (PurchaseOrder))]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult GetSalesOrderById (uint id) {
            var result = _query.GetSalesOrderById (id);
            if (result == null) {
                return StatusCode (404);
            }

            return StatusCode (200, result);
        }

        [HttpPost (Name = "CreateSalesOrder")]
        [ProducesResponseType (201, Type = typeof (PurchaseOrder))]
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
            List<PurchaseOrder> orders = new List<PurchaseOrder> ();
            var client = _customerQuery.GetCustomerById (newOrder.ClientId);

            if (client == null) {
                ModelState.AddModelError ("ClientId", $"Customer with id: {newOrder.ClientId} Not Found");
            }

            var employee = _employeeQuery.GetEmployeeById (newOrder.CreatedBy);

            if (employee == null) {
                ModelState.AddModelError ("CreatedBy", $"Employee with id: {newOrder.CreatedBy} Not Found");
            }

            foreach (var orderDetail in newOrder.orderDetail) {
                var product = _itemQuery.GetProductById (orderDetail.ItemId);
                if (product == null) {
                    ModelState.AddModelError ("ItemId", $"Product With id: {orderDetail.ItemId} Not Found");
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                var salesOrder = _factory.CreateNewSaleOrder (client,
                    employee,
                    product,
                    orderDetail.Quantity,
                    orderDetail.DueDate,
                    orderDetail.UnitPrice,
                    newOrder.InitialPayment,
                    newOrder.PaymentMethod
                    );

                orders.Add (salesOrder);

            }

            var result = _command.CreateSalesOrder (orders);
            if (result == null) {
                return StatusCode (500);
            }

            return StatusCode (201, result);

        }

    }
}