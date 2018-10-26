/*
 * @CreateTime: Oct 23, 2018 12:08 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 24, 2018 11:05 PM
 * @Description: Modify Here, Please 
 */


using System;
using BionicInventory.API.Controllers.WorkOrders.Interface;
using BionicInventory.Application.Products.Interfaces;
using BionicInventory.Application.Products.Interfaces.Booking;
using BionicInventory.Application.Products.Models;
using BionicInventory.Commons;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.Products {
    [InventoryAPI ("Products")]
    public class StockBookingController : Controller {
        private readonly IStockBookingQuey _bookingQuery;

        public StockBookingController(IStockBookingQuey bookingQuery) {
        
                _bookingQuery = bookingQuery;
        }

        [HttpGet("bookings/available")]
       public IActionResult GetStocksBookingAvailablity() {
            
            var x = _bookingQuery.getAvailableFinishedProduct();
            return StatusCode(200, x);
        }
    
    }

}