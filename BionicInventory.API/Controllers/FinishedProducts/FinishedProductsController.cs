using System;
using System.Collections.Generic;
using BionicInventory.Application.Employees.Interfaces;
using BionicInventory.Application.FinishedProducts.Interfaces;
using BionicInventory.Application.FinishedProducts.Models;
using BionicInventory.Application.ProductionOrders.Iterfaces;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.FinishedProducts {
    public class FinishedProductsController : Controller {

        private readonly IFinishedProductsCommand _command;
        private readonly IFinishedProductsQuery _query;
        private readonly IFinishedProductsFactories _factory;
        private readonly IEmployeesQuery _employeesQuery;
        private readonly IWorkOrdersQuery _productionOrderQuery;

        public FinishedProductsController (
            IFinishedProductsCommand command,
            IFinishedProductsQuery query,
            IFinishedProductsFactories factory,
            IWorkOrdersQuery productionOrderQuery,
            IEmployeesQuery employeesQuery
        ) {
            _command = command;
            _query = query;
            _factory = factory;
            _employeesQuery = employeesQuery;
            _productionOrderQuery = productionOrderQuery;
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
            } catch (Exception) {
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

            } catch (Exception) {

                return StatusCode (500, "Unkown Error Occured while processing Request, Try Again");
            }
        }

        [HttpPost]
        [ProducesResponseType (201, Type = typeof (FinishedProductsViewModel))]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public IActionResult AddFinishedProduct ([FromBody] FinishedProductDTO newFinishedProduct) {

            if (ModelState.IsValid && newFinishedProduct != null) {

                try {
                    var submittedBy = _employeesQuery.GetEmployeeById (newFinishedProduct.submittedBy);
                    var recievedBy = _employeesQuery.GetEmployeeById (newFinishedProduct.recievedBy);
                    var order = _productionOrderQuery.GetWorkOrderById (newFinishedProduct.orderId);

                    var finishedProduct = _factory.NewFinishedProduct (order, submittedBy, recievedBy, newFinishedProduct.quantity);

                    var result = _command.AddFinishedProduct (finishedProduct);
                    if (result != null) {
                        return StatusCode (201, result);
                    } else {
                        return StatusCode (422, "One or more required fields missing for employee");
                    }

                } catch (System.Exception) {
                    return StatusCode (500, "Unkown Error Occured while processing Request, Try Again");
                }
            } else {
                return StatusCode (422, "One or more required fields missing for employee");
            }
        }

        [HttpPut ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public IActionResult UpdateFinishedProductRecord (uint id, [FromBody] FinishedProductDTO updatedData) {

                try {
            if (ModelState.IsValid && updatedData != null) {

                var finishedProduct = _query.GetFinishedProductById (id);
                if (finishedProduct != null) {
                    var updatedFinishedProduct = _factory.FinishedProductForUpdate (finishedProduct, updatedData);

                    if (_command.UpdateFinishedProduct (updatedFinishedProduct)) {
                        return StatusCode (204);
                    } else {
                        return StatusCode (500, "Unkown Error Occured while processing Request, Try Again");
                    }

                } else {
                    return StatusCode (404);
                }

            } else {
                return StatusCode (422, "One or more required fields missing for employee");
            }
                } catch(Exception e) {
                    return StatusCode(500, e);
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