/*
 * @CreateTime: Sep 10, 2018 11:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 11, 2018 2:12 AM
 * @Description: WorkOrder API Controller Class
 */
using System;
using System.Collections.Generic;
using BionicInventory.Application.Employees.Interfaces;
using BionicInventory.Application.ProductionOrders.Iterfaces;
using BionicInventory.Application.ProductionOrders.Models;
using BionicInventory.Application.Products.Interfaces;
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
        private readonly IProductsQuery _productsQuery;
        private readonly IEmployeesQuery _employeeQuery;

        public WorkOrdersController (IWorkOrdersCommand commands,
            IWorkOrdersFactory factory,
            IWorkOrdersQuery query,
            IResponseFormatFactory resposeFactory,
            IEmployeesQuery employeeQuery,
            IProductsQuery productsQuery) {
            _command = commands;
            _query = query;
            _factory = factory;
            _response = resposeFactory;
            _productsQuery = productsQuery;

            _employeeQuery = employeeQuery;
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

            } catch (Exception e) {
                return StatusCode (500, e.Message);
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

                return StatusCode (200, order);

            } catch (Exception e) {
                return StatusCode (500, e.Message);
            }
        }

        [HttpGet ("{id}/items/{itemId}")]
        [ProducesResponseType (200, Type = typeof (WorkOrderView))]
        [ProducesResponseType (500)]
        [ProducesResponseType (404)]
        public IActionResult GetWorkOrderById (uint id, uint itemId) {

            try {

                var order = _query.GetWorkOrderById (id);
                var orderItem = _query.GetWorkOrderItemById (itemId);

                if (order == null || orderItem == null) {
                    return StatusCode (404, orderItem);
                }
                var orderView = _factory.CreateWorkOrderView (orderItem);

                return StatusCode (200, orderView);

            } catch (Exception e) {
                return StatusCode (500, e.Message);
            }

        }

        [HttpPost]
        [ProducesResponseType (201, Type = typeof (IEnumerable<WorkOrderView>))]
        [ProducesResponseType (422)]
        [ProducesResponseType (409)]
        [ProducesResponseType (500)]
        public IActionResult CreateNewWorkWorder ([FromBody] NewWorkOrderDto newWork) {

            try {

                if (!ModelState.IsValid || newWork == null) {
                    return StatusCode (422);
                }

                var employee = _employeeQuery.GetEmployeeById (newWork.OrderedBy);

                if (employee == null) {
                    return StatusCode (404, "Employee Record Not Found");
                }

                foreach (var products in newWork.workOrderItems) {
                    var product = _productsQuery.GetProductById (products.ItemId);
                    if (product == null) {
                        return StatusCode (404, "Product Record Not Found");
                    }
                }

                var workorder = _factory.CreateNewWorkOrder (newWork);

                var result = _command.CreateNewWorkOrder (workorder);

                if (result != null) {

                    var workOrderView = _factory.CreateWorkOrderView (result);
                    return StatusCode (201, workOrderView);

                } else {

                    return StatusCode (500, "Server error Try Again");
                }

            } catch (Exception e) {
                return StatusCode (500, e.Message);
            }

        }

        [HttpPut]
        [ProducesResponseType (204, Type = typeof (IEnumerable<WorkOrderView>))]
        [ProducesResponseType (422)]
        [ProducesResponseType (409)]
        [ProducesResponseType (500)]
        public IActionResult UpdateWorkWorder ([FromBody] UpdatedWorkOrderDto updated) {

            try {

                if (!ModelState.IsValid || updated == null) {
                    return StatusCode (422, ModelState);
                }

                var employee = _employeeQuery.GetEmployeeById (updated.OrderedBy);

                if (employee == null) {
                    return StatusCode (404, "Employee Record Not Found");
                }

                foreach (var products in updated.workOrderItems) {
                    var product = _productsQuery.GetProductById (products.ItemId);
                    if (product == null) {
                        return StatusCode (404, "Product Record Not Found");
                    }
                }

                var workorder = _factory.CreateUpdatedWorkOrder (updated);

                var result = _command.UpdateWorkOrder (workorder);

                if (result != null) {

                    return StatusCode (204);

                } else {

                    return StatusCode (500, "Server error Try Again");
                }

            } catch (Exception e) {
                return StatusCode (500, e.Message);
            }

        }

        [HttpDelete ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult DeleteWorkOrder (uint id) {

            try {
                var work = _query.GetWorkOrderById (id);

                if (work == null) {
                    return StatusCode (404);
                }

                var result = _command.DeleteWorkOrder (work);

                if (result) {
                    return StatusCode (204);
                } else {
                    return StatusCode (500, "Unknown Error Occured Try Again Late");
                }

            } catch (Exception e) {
                return StatusCode (500, e.Message);
            }

        }

        [HttpDelete ("{id}/items/{itemId}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult DeleteWorkOrderItem (uint id, uint itemId) {

            try {

                var work = _query.GetWorkOrderById (id);
                var workItem = _query.GetWorkOrderItemById (itemId);

                if (work == null || workItem == null) {
                    return StatusCode (404, workItem);
                }

                var result = _command.DeleteWorkOrderItem (workItem);

                if (result) {
                    return StatusCode (204);
                } else {
                    return StatusCode (500, "Unknown Error Occured Try Again Late");
                }

            } catch (Exception e) {
                return StatusCode (500, e.Message);
            }

        }

    }
}