/*
 * @CreateTime: Sep 10, 2018 11:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2018 11:42 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Application.ProductionOrders.Iterfaces;
using BionicInventory.Application.ProductionOrders.Models;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.WorkOrders {
    [InventoryAPI ("workorders")]
    public class WorkOrdersController : Controller {
        private readonly IWorkOrdersCommand _command;
        private readonly IWorkOrdersQuery _query;
        private readonly IWorkOrdersFactory _factory;
        private readonly IResponseFormatFactory _response;

        public WorkOrdersController (IWorkOrdersCommand commands,
            IWorkOrdersFactory factory,
            IWorkOrdersQuery query,
            IResponseFormatFactory resposeFactory) {
            _command = commands;
            _query = query;
            _factory = factory;
            _response = resposeFactory;
        }

        [HttpGet]
        [ProducesResponseType (200, Type = typeof (IEnumerable<WorkOrderView>))]
        [ProducesResponseType (500)]
        public IActionResult GetAllWorkOrders () {
            try {
                
                var orders = _query.GetAllWorkOrders ();
                
                if (orders != null) {
                
                    var orderView = _factory.CreateWorkOrderViewList (orders);
                    var response = _response.DataForPresentation ((List<WorkOrderView>) orderView);
                    return StatusCode (200, response);
                
                } else {
                    return StatusCode (200, orders);
                }

            } catch (Exception) {
                return StatusCode (500, "Error Occured Try again");
            }
        }

        [HttpGet ("{id}")]
        [ProducesResponseType (200, Type = typeof (IEnumerable<WorkOrderView>))]
        [ProducesResponseType (500)]
        [ProducesResponseType (404)]
        public IActionResult GetWorkOrderById (uint id) {

            try {
                var order = _query.GetWorkOrderById (id);

                if (order == null) {
                    return StatusCode (404);
                }
                var orderView = _factory.CreateWorkOrderView (order);

                return StatusCode (200, orderView);
            } catch (Exception) {
                return StatusCode (500, "Error Occured Try again");
            }
        }

    }
}