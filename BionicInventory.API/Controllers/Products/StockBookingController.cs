/*
 * @CreateTime: Oct 23, 2018 12:08 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By: undefined
 * @Last Modified Time: Oct 31, 2018 10:59 PM
 * @Description: Modify Here, Please 
 */

using System;
using BionicInventory.Application.Products.Interfaces;
using BionicInventory.Application.Products.Interfaces.Booking;
using BionicInventory.Application.Products.Models;
using BionicInventory.Application.SalesOrders.Interfaces;
using BionicInventory.API.Controllers.WorkOrders.Interface;
using BionicInventory.Commons;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.Products {
    [InventoryAPI ("Products")]
    public class StockBookingController : Controller {
        private readonly IStockBookingQuery _bookingQuery;
        private readonly ISalesOrderQuery _customerOrderQuery;

        public StockBookingController (IStockBookingQuery bookingQuery,
            ISalesOrderQuery customerOrderQuery) {

            _bookingQuery = bookingQuery;
            _customerOrderQuery = customerOrderQuery;
        }

        [HttpGet ("bookings/{id}")]
        public IActionResult GetStocksBookingAvailablity (uint id, string type = "BOOKED") {
            Object bookings;

            bookings = _bookingQuery.GetAvailableCustomerOrderItem (id);

            return StatusCode (200, bookings);
        }

    }

}