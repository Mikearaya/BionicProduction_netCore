using BionicInventory.Application.ProductionOrders.Iterfaces;
using BionicInventory.Application.ProductionOrders.Models;
using BionicInventory.Commons;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.WorkOrders {
    [InventoryAPI ("workorders")]
    public class WorkOrdersController : Controller {
        private readonly IWorkOrdersCommand _command;
        private readonly IWorkOrdersQuery _query;
        private readonly IWorkOrdersFactory _factory;

        public WorkOrdersController (IWorkOrdersCommand commands,
            IWorkOrdersFactory factory,
            IWorkOrdersQuery query) {
            _command = commands;
            _query = query;
            _factory = factory;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(WorkOrderView))]
        [ProducesResponseType(500)]
        public IActionResult GetAllWorkOrders() {
            var orders = _query.GetAllWorkOrders();
            return StatusCode(200, orders);
        }


    }
}