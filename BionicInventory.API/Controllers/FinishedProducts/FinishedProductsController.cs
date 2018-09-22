/*
 * @CreateTime: Sep 14, 2018 10:22 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 21, 2018 10:45 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Application.Employees.Interfaces;
using BionicInventory.Application.FinishedProducts.Interfaces;
using BionicInventory.Application.FinishedProducts.Models;
using BionicInventory.Application.ProductionOrders.Iterfaces;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BionicInventory.Domain.FinishedProducts;

namespace BionicInventory.API.Controllers.FinishedProducts {

    [InventoryAPI ("finished_products")]
    public class FinishedProductsController : Controller {

        private readonly IFinishedProductsCommand _command;
        private readonly IFinishedProductsQuery _query;
        private readonly IFinishedProductsFactories _factory;
        private readonly IEmployeesQuery _employeesQuery;
        private readonly IWorkOrdersQuery _productionOrderQuery;
        private readonly ILogger<FinishedProductsController> _logger;

        public FinishedProductsController (
            IFinishedProductsCommand command,
            IFinishedProductsQuery query,
            IFinishedProductsFactories factory,
            IWorkOrdersQuery productionOrderQuery,
            IEmployeesQuery employeesQuery,
            ILogger<FinishedProductsController> logger
        ) {
            _command = command;
            _query = query;
            _factory = factory;
            _employeesQuery = employeesQuery;
            _productionOrderQuery = productionOrderQuery;
            _logger = logger;
        }

        [HttpGet ("{id}")]
        [ProducesResponseType (200, Type = typeof (FinishedProductsViewModel))]
        [ProducesResponseType (404)]
        [ProducesResponseType (400)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public IActionResult GetFinishedProductsById (uint id) {

            try {

                if (id == 0) {
                    return StatusCode (400);
                }

                var finishedProduct = _query.GetFinishedProductById (id);

                if (finishedProduct == null) {
                    return StatusCode (404);
                }

                var finishedProductView = _factory.FinishedProductForView (finishedProduct);

                return StatusCode (200, finishedProductView);

            } catch (Exception e) {
                _logger.LogError (e.Message);
                return StatusCode (500, "Unkown Error Occured while processing Request, Try Again");
            }

        }

        [HttpGet]
        [ProducesResponseType (200, Type = typeof (FinishedProductsViewModel))]
        [ProducesResponseType (500)]
        public IActionResult GetAllFinishedProducts () {

            try {

                var finishedProducts = _query.GetAllFinishedProducts ();
                List<FinishedProductsViewModel> finishedProductsList = new List<FinishedProductsViewModel> ();

                return StatusCode (200, finishedProducts);

            } catch (Exception e) {
                _logger.LogError (e.Message);
                return StatusCode (500, e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType (201, Type = typeof (FinishedProductsViewModel))]
        [ProducesResponseType (422)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public IActionResult AddFinishedProduct ([FromBody] IEnumerable<NewFinishedProductDto> newFinishedProduct) {

            
                List<FinishedProduct> finishedProductsList = new List<FinishedProduct>();

                if (newFinishedProduct == null) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }
                foreach (var item in newFinishedProduct) {
                    var submittedBy = _employeesQuery.GetEmployeeById (item.submittedBy);
                    var recievedBy = _employeesQuery.GetEmployeeById (item.recievedBy);

                    if (submittedBy == null || recievedBy == null) {
                        return StatusCode (404, "Employee Not Found");
                    }

                    var order = _productionOrderQuery.GetWorkOrderItemById (item.orderId);
                    if (order == null) {
                        return StatusCode (404, "Order Not Found");
                    }

                    var finishedProduct = _factory.NewFinishedProduct (order, submittedBy, recievedBy, item.quantity);
                

                    finishedProductsList.Add(finishedProduct);
                }

                

                var result = _command.AddFinishedProduct (finishedProductsList);

                if (result != null) {

                    var finishedProductView = _factory.FinishedProductForView (result);
                    return StatusCode (201, finishedProductView);

                } else {
                    return StatusCode (500, "Unkown Error Please try again later");
                }

     
        }

        [HttpPut]
        [HttpPut ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (422)]
        [ProducesResponseType (400)]
        [ProducesResponseType (500)]
        public IActionResult UpdateFinishedProductRecord (uint id, [FromBody] UpdatedFinishedProductDto updatedData) {

            try {
                if (updatedData == null) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                id = (id == 0) ? (uint) updatedData.id : id;

                var finishedProduct = _query.GetFinishedProductById (id);

                if (finishedProduct == null) {
                    return StatusCode (404, $"Product with id: {id} Not Found : ");
                }

                var submittedBy = _employeesQuery.GetEmployeeById (updatedData.submittedBy);
                var recievedBy = _employeesQuery.GetEmployeeById (updatedData.recievedBy);

                if (submittedBy == null || recievedBy == null) {
                    return StatusCode (404, "Employee Not Found");
                }

                var order = _productionOrderQuery.GetWorkOrderItemById (updatedData.orderId);

                if (order == null) {
                    return StatusCode (404, "Order Not Found");
                }

                var updatedFinishedProduct = _factory.FinishedProductForUpdate (updatedData);

                if (_command.UpdateFinishedProduct (updatedFinishedProduct)) {
                    return StatusCode (204);
                } else {
                    return StatusCode (500, "Unkown Error Occured while processing Request, Try Again");
                }

            } catch (Exception e) {
                _logger.LogError (500, e.Message, e);

                return StatusCode (500, e);
            }

        }

        [HttpDelete ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult DeleteSingleFinishedProductEntry (uint id) {

            try {

                if (id == 0) {
                    return StatusCode (400);
                }
                var finishedProduct = _query.GetFinishedProductById (id);

                if (finishedProduct == null) {
                    return StatusCode (422);
                }

                if (_command.DeleteFinishedProduct (finishedProduct)) {
                    return StatusCode (204);
                } else {
                    return StatusCode (500, "Unknown Error Pleace try again later");
                }

            } catch (Exception e) {
                _logger.LogError (500, e.Message, e);

                return StatusCode (500, e);
            }

        }
    }
}