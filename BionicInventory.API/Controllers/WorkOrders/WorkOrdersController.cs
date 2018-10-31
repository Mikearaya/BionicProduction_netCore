/*
 * @CreateTime: Sep 10, 2018 11:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 23, 2018 12:41 AM
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
using Microsoft.Extensions.Logging;
using BionicInventory.Application.SalesOrders.Interfaces;
using BionicInventory.API.Controllers.WorkOrders.Interface;

namespace BionicInventory.API.Controllers.WorkOrders {
    [InventoryAPI ("workorders")]
    public class WorkOrdersController : Controller, IWorkOrder {
        private readonly IWorkOrdersCommand _command;
        private readonly IWorkOrdersQuery _query;
        private readonly IWorkOrdersFactory _factory;
        private readonly IResponseFormatFactory _response;
        private readonly IProductsQuery _productsQuery;
        private readonly ILogger<WorkOrdersController> _logger;
        private readonly IEmployeesQuery _employeeQuery;

        private readonly ISalesOrderQuery _salesQuery;

        public WorkOrdersController (IWorkOrdersCommand commands,
            IWorkOrdersFactory factory,
            IWorkOrdersQuery query,
            IResponseFormatFactory resposeFactory,
            IEmployeesQuery employeeQuery,
            IProductsQuery productsQuery,
            ILogger<WorkOrdersController> logger,
            ISalesOrderQuery salesQuery) {
            _command = commands;
            _query = query;
            _factory = factory;
            _response = resposeFactory;
            _productsQuery = productsQuery;
            _salesQuery = salesQuery;
            _logger = logger;

            _employeeQuery = employeeQuery;
        }

        [HttpGet]
        [ProducesResponseType (200, Type = typeof (IEnumerable<WorkOrderView>))]
        [ProducesResponseType (500)]
        public IActionResult GetAllWorkOrders (String type = "ALL", uint salesOrderItemId = 0) {
            try {
                Object orders = null;
                if (type.ToUpper () == "PENDING") {
                    if(salesOrderItemId != 0) {
                    orders = _query.GetPendingWorkOrder (salesOrderItemId);
                    } else {
                        orders = _query.GetPendingWorkOrders ();
                    }

                } else if (type.ToUpper () == "ACTIVE") {
                    orders = _query.GetActiveWorkOrders ();
                } else {
                    orders = _query.GetWorkOrdersStatus ();
                }

                if (orders != null) {

                    return StatusCode (200, orders);

                } else {
                    return StatusCode (500);
                }

            } catch (Exception e) {
                _logger.LogError (500, e.Message, e);
                return StatusCode (500, e.Message);
            }
        }

        [HttpGet ("{id}")]
        [ProducesResponseType (200, Type = typeof (IEnumerable<WorkOrderView>))]
        [ProducesResponseType (500)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        public IActionResult GetWorkOrderById (uint id) {

       
        
                if (id == 0) {
                    return StatusCode (400);
                }

                var order = _query.GetWorkOrderItemById (id);

                if (order == null) {
                    return StatusCode (404);
                }

                return StatusCode (200, order);


        }


        [HttpPost]
        [ProducesResponseType (201, Type = typeof (IEnumerable<WorkOrderView>))]
        [ProducesResponseType (422)]
        [ProducesResponseType (409)]
        [ProducesResponseType (500)]
        public IActionResult CreateNewWorkWorder ([FromBody] NewWorkOrderDto newWork) {
                if (newWork == null) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                var employee = _employeeQuery.GetEmployeeById (newWork.OrderedBy);

                if (employee == null) {
                    return StatusCode (404, "Employee Record Not Found");
                }


                    var product = _productsQuery.GetProductById (newWork.ItemId);
                    if (product == null) {
                        return StatusCode (404, "Product Record Not Found");
                    }

                    if(newWork.PurchaseOrderItemId != 0) {
                        var salesOrder = _salesQuery.GetSalesOrderItemById((uint)newWork.PurchaseOrderItemId);
                        if(salesOrder == null) {
                            return StatusCode (404, $"Sales Order with id {newWork.PurchaseOrderItemId} Not Found");
                        }

                        if(_query.saleOrderProductionExits((uint)newWork.PurchaseOrderItemId)) {
                            ModelState.AddModelError("PurchaseOrderId", $"Sale Order With Id : {newWork.PurchaseOrderItemId} already has a manufacturing Order");
                            return new InvalidInputResponse(ModelState);
                        }
                        newWork.Quantity = salesOrder.Quantity;
                    }
                

                var workorder = _factory.CreateNewWorkOrder (newWork);

                var result = _command.CreateNewWorkOrder (workorder);

                if (result != null) {

                    var workOrderView = _factory.CreateWorkOrderView (result);
                    return StatusCode (201, workOrderView);

                } else {

                    return StatusCode (500, "Server error Try Again");
                }


        }

        [HttpPut("{id}")]
        [ProducesResponseType (204, Type = typeof (IEnumerable<WorkOrderView>))]
        [ProducesResponseType (422)]
        [ProducesResponseType (400)]
        [ProducesResponseType (409)]
        [ProducesResponseType (500)]
        public IActionResult UpdateWorkWorder (uint id, [FromBody] UpdatedWorkOrderDto updated) {

       

                if (updated == null) {
                    return StatusCode (400, ModelState);
                }
                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                var employee = _employeeQuery.GetEmployeeById (updated.OrderedBy);

                if (employee == null) {
                    return StatusCode (404, "Employee Record Not Found");
                }

                    var product = _productsQuery.GetProductById (updated.ItemId);
                
                    if (product == null) {
                        return StatusCode (404, "Product Record Not Found");
                    }
                

                var workorder = _factory.CreateUpdatedWorkOrder (updated);

                var result = _command.UpdateWorkOrder (workorder);

                if (result != null) {

                    return StatusCode (204);

                } else {

                    return StatusCode (500, "Server error Try Again");
                }

    

        }

        [HttpDelete ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult DeleteWorkOrder (uint id) {

            try {

                if (id == 0) {
                    return StatusCode (400);
                }

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
                _logger.LogError (500, e.Message, e);
                return StatusCode (500, e.Message);
            }

        }


    }
}