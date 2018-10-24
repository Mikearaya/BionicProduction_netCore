/*
 * @CreateTime: Oct 24, 2018 11:07 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 24, 2018 11:15 PM
 * @Description: Modify Here, Please 
 */





using BionicInventory.Application.Products.Interfaces.Booking;
using BionicInventory.Application.Products.Models.BookingModel;
using BionicInventory.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BionicInventory.API.Controllers.SalesOrders.Booking {

[InventoryAPI ("salesorders")]
public class CustomerOrderBookingController: Controller {
        private readonly ILogger<CustomerOrderBookingController> _logger;
        private readonly IStockBookingQuery _bookingQuery;

        public CustomerOrderBookingController(IStockBookingQuery bookingQuery,
                                                    ILogger<CustomerOrderBookingController> logger) {
                        _logger = logger;
                        _bookingQuery = bookingQuery;
        }


        [HttpGet ("{id}/booking")]
        [ProducesResponseType (200, Type = typeof (CustomerOrderBookings))]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult GetSalesOrderById (uint id) {

        
    if(id == 0) {
        return StatusCode(400, "Invalid Customer Order Id");
    }
            var result = _bookingQuery.GetCustomerOrderBookings(id);
            if (result == null) {
                return StatusCode (404);
            }

            return StatusCode (200, result);
        }



}

}