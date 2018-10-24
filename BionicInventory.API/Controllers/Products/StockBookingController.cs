/*
 * @CreateTime: Oct 23, 2018 12:08 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 24, 2018 11:05 PM
 * @Description: Modify Here, Please 
 */


using BionicInventory.API.Controllers.WorkOrders.Interface;
using BionicInventory.Application.Products.Interfaces;
using BionicInventory.Application.Products.Models;
using BionicInventory.Commons;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.Products {
    [InventoryAPI ("Products")]
    public class StockBookingController : Controller {
        private readonly IStockBookingCommand _bookingCommand;
        private readonly IStockBookingFactory _bookingFactory;
        private readonly IWorkOrder _manufactureOrder;

        public StockBookingController(IStockBookingCommand bookingCommand,
                                    IStockBookingFactory bookingFactory,
                                    IWorkOrder workOrderController) {
                _bookingCommand = bookingCommand;
                _bookingFactory = bookingFactory;
                _manufactureOrder = workOrderController;
        }

        IActionResult GetStocksBookingAvailablity(uint id) {
            return StatusCode(200);
        }
    
    }

}