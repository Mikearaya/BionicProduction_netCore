/*
 * @CreateTime: Oct 24, 2018 11:07 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 3, 2018 10:09 PM
 * @Description: Modify Here, Please 
 */

using System;
using System.Collections.Generic;
using BionicInventory.Application.ProductionOrders.Iterfaces;
using BionicInventory.Application.ProductionOrders.Models;
using BionicInventory.Application.Products.Interfaces.Booking;
using BionicInventory.Application.Products.Models.BookingModel;
using BionicInventory.Application.SalesOrders.Interfaces;
using BionicInventory.Application.SalesOrders.Models.Booking;
using BionicInventory.API.Commons;
using BionicInventory.API.Controllers.WorkOrders.Interface;
using BionicInventory.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BionicInventory.API.Controllers.SalesOrders.Booking {

    [InventoryAPI ("salesorders")]
    public class CustomerOrderBookingController : Controller {
        private readonly ILogger<CustomerOrderBookingController> _logger;
        private readonly IStockBookingQuery _bookingQuery;
        private readonly IStockBookingCommand _bookingCommand;
        private readonly IStockBookingFactory _bookingFactory;
        private readonly ISalesOrderQuery _salesOrderQuery;
        private readonly IWorkOrder _workOrderController;
        private readonly IWorkOrdersFactory _workOrderFactory;

        public CustomerOrderBookingController (IStockBookingQuery bookingQuery,
            ILogger<CustomerOrderBookingController> logger,
            IWorkOrder workOrderController,
            IStockBookingCommand command,
            ISalesOrderQuery saleOrderQuery,
            IWorkOrdersFactory workOrderFactory,
            IStockBookingFactory factory) {
            _logger = logger;
            _bookingQuery = bookingQuery;
            _salesOrderQuery = saleOrderQuery;
            _bookingCommand = command;
            _bookingFactory = factory;
            _workOrderController = workOrderController;
            _workOrderFactory = workOrderFactory;
        }

        [HttpGet ("{id}/booking")]
        [ProducesResponseType (200, Type = typeof (CustomerOrderBookings))]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult GetSalesOrderById (uint id) {

            var result = _bookingQuery.GetCustomerOrderBookings (id);

            return StatusCode (200, result);
        }

        [HttpPost ("{id}/booking")]
        [ProducesResponseType (200, Type = typeof (CustomerOrderBookings))]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult BookCustomerOrderItems (uint id, [FromBody] OrderItemBookingDto orderItem) {

            if (orderItem == null) {
                return StatusCode (400);
            }
            if (!ModelState.IsValid) {
                return new InvalidInputResponse (ModelState);
            }

            var salesOrder = _salesOrderQuery.GetSalesOrderById (id);
            if (salesOrder == null) {
                return StatusCode (404, $"Customer Order with id {id} Not Found");
            }

            foreach (var item in orderItem.Items) {
                var customerOrderItem = _salesOrderQuery.GetSalesOrderItemById (item.CustomerOrderItemId);
                if (customerOrderItem == null) {
                    return StatusCode (404, $"Customer Order Item with id {item.CustomerOrderItemId} Not Found");
                }
                var availableStock = _bookingQuery.AvailableStockItemsForOrder ((int) item.Quantity, item.CustomerOrderItemId);
                if (availableStock.Count != 0) {
                    var bookedItems = _bookingFactory.CreateBooking (availableStock, item.CustomerOrderItemId, orderItem.BookedBy);
                    var booked = _bookingCommand.BookAvailableStockItems (bookedItems);

                }

                if (availableStock.Count < item.Quantity && orderItem.CreateManufactureOrder == 1) {

                    var workDto = _workOrderFactory.CreateCustomerOrderDto (
                        item.CustomerOrderItemId,
                        customerOrderItem.ItemId,
                        (uint) (item.Quantity - availableStock.Count),
                        (DateTime) orderItem.WorkEndDate,
                        (DateTime) orderItem.WorkEndDate,
                        orderItem.BookedBy,
                        "Created From Factory"
                    );
                    var workResult = _workOrderController.CreateNewWorkWorder (workDto);

                    if (workResult.GetType () == typeof (InvalidInputResponse)) {
                        return workResult;
                    }

                }

            }

            return StatusCode (201);
        }

    }

}