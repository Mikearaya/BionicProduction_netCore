/*
 * @CreateTime: Sep 14, 2018 10:22 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 15, 2018 12:09 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Application.Employees.Interfaces;
using BionicInventory.Application.FinishedProducts.Interfaces;
using BionicInventory.Application.FinishedProducts.Models;
using BionicInventory.Application.ProductionOrders.Iterfaces;
using BionicInventory.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public IActionResult GetFinishedProductsById (uint id) {

            try {
                var finishedProduct = _query.GetFinishedProductById (id);

                if (finishedProduct != null) {
                    var finishedProductView = _factory.FinishedProductForView (finishedProduct);
                    return StatusCode (200, finishedProductView);
                } else {
                    return StatusCode (404);
                }
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

                foreach (var finishedProduct in finishedProducts) {
                    finishedProductsList.Add (_factory.FinishedProductForView (finishedProduct));
                }

                return StatusCode (200, finishedProductsList);

            } catch (Exception e) {
                _logger.LogError (e.Message);
                return StatusCode (500, e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType (201, Type = typeof (FinishedProductsViewModel))]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public IActionResult AddFinishedProduct ([FromBody] FinishedProductDTO newFinishedProduct) {

            try {

                if (ModelState.IsValid && newFinishedProduct != null) {

                    var submittedBy = _employeesQuery.GetEmployeeById (newFinishedProduct.submittedBy);
                    var recievedBy = _employeesQuery.GetEmployeeById (newFinishedProduct.recievedBy);

                    if (submittedBy == null || recievedBy == null) {
                        return StatusCode (404, "Employee Not Found");
                    }

                    var order = _productionOrderQuery.GetWorkOrderItemById (newFinishedProduct.orderId);

                    if (order == null) {
                        return StatusCode (404, "Order Not Found");
                    }

                    var finishedProduct = _factory.NewFinishedProduct (order, submittedBy, recievedBy, newFinishedProduct.quantity);

                    var result = _command.AddFinishedProduct (finishedProduct);

                    if (result != null) {

                        var finishedProductView = _factory.FinishedProductForView (result);
                        return StatusCode (201, finishedProductView);

                    } else {
                        return StatusCode (422, "One or more required fields missing for employee");
                    }

                } else {
                    return StatusCode (422, "One or more required fields missing for employee");
                }

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);
                return StatusCode (500);
            }
        }

        [HttpPut]
        [HttpPut ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public IActionResult UpdateFinishedProductRecord (uint id, [FromBody] FinishedProductDTO updatedData) {

            try {
                if (ModelState.IsValid && updatedData != null) {

                    uint finishedProductId = 0;

                    if (id == 0) {
                        finishedProductId = (uint) updatedData.id;
                    } else {
                        finishedProductId = id;
                    }
                    var finishedProduct = _query.GetFinishedProductById (finishedProductId);

                    if (finishedProduct == null) {
                        return StatusCode (404, finishedProductId);
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

                    var updatedFinishedProduct = _factory.FinishedProductForUpdate (finishedProduct, updatedData);

                    if (_command.UpdateFinishedProduct (updatedFinishedProduct)) {
                        return StatusCode (204);
                    } else {
                        return StatusCode (500, "Unkown Error Occured while processing Request, Try Again");
                    }

                } else {

                    return StatusCode (422, "One or more required fields missing for employee");
                }
            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);

                return StatusCode (500, e);
            }

        }

        [HttpDelete ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult DeleteSingleFinishedProductEntry (uint id) {

            try {
                var finishedProduct = _query.GetFinishedProductById (id);

                if (finishedProduct != null) {

                    if (_command.DeleteFinishedProduct (finishedProduct)) {
                        return StatusCode (204);
                    } else {
                        return StatusCode (422);
                    }

                } else {

                    return StatusCode (404);
                }
            } catch (Exception) {

                return StatusCode (500, "Unkown Error Occured while processing Request, Try Again");
            }

        }
    }
}