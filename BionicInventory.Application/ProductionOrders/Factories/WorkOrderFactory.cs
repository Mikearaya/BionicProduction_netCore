/*
 * @CreateTime: Sep 10, 2018 8:32 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 11, 2018 2:09 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BionicInventory.Application.Employees.Interfaces;
using BionicInventory.Application.ProductionOrders.Iterfaces;
using BionicInventory.Application.ProductionOrders.Models;
using BionicInventory.Application.ProductionOrders.Models.WorkOrdersList;
using BionicInventory.Application.Products.Interfaces;
using BionicInventory.Domain.ProductionOrders;
using BionicInventory.Domain.ProductionOrders.ProductionOrderLists;

namespace BionicInventory.Application.ProductionOrders.Factories {
    public class WorkOrderFactory : IWorkOrdersFactory {
        private readonly IEmployeesQuery _employeeQuery;

        public IProductsQuery _productsQuery { get; }

        public WorkOrderFactory (IEmployeesQuery employeeQuery, IProductsQuery productsQuery) {
            _employeeQuery = employeeQuery;
            _productsQuery = productsQuery;
        }
        public ProductionOrder CreateNewWorkOrder (NewWorkOrderDto newOrder) {

            try {

                ProductionOrder productionOrder = new ProductionOrder () {
                    Description = newOrder.Description,
                    OrderedBy = newOrder.OrderedBy

                };

                foreach (var item in newOrder.workOrderItems) {
                    ProductionOrderList list = new ProductionOrderList () {
                        ItemId = item.ItemId,
                        CostPerItem = item.CostPerItem,
                        Quantity = item.Quantity,
                        DueDate = item.DueDate,

                    };
                    productionOrder.ProductionOrderList.Add (list);
                }

                return productionOrder;

            } catch (Exception) {
                return null;
            }
        }

        public ProductionOrder CreateUpdatedWorkOrder (UpdatedWorkOrderDto newOrder) {

            try {

                ProductionOrder productionOrder = new ProductionOrder () {
                    Description = newOrder.Description,
                    OrderedBy = newOrder.OrderedBy,
                    Id = newOrder.Id

                };

                foreach (var item in newOrder.workOrderItems) {
                    ProductionOrderList list = new ProductionOrderList () {
                        Id = (item.Id > 0) ? (uint) item.Id : 0,
                        ItemId = item.ItemId,
                        CostPerItem = item.CostPerItem,
                        Quantity = item.Quantity,
                        DueDate = item.DueDate,

                    };
                    productionOrder.ProductionOrderList.Add (list);
                }

                return productionOrder;

            } catch (Exception) {
                return null;
            }
        }

        public IEnumerable<WorkOrderView> CreateWorkOrderView (ProductionOrder workOrder) {

            try {

                var employee = _employeeQuery.GetEmployeeById (workOrder.OrderedBy);

                List<WorkOrderView> workorderView = new List<WorkOrderView> ();

                foreach (var item in workOrder.ProductionOrderList) {
                    var product = _productsQuery.GetProductById (item.ItemId);
                    WorkOrderView view = new WorkOrderView () {
                        id = item.ProductionOrderId,
                        orderId = item.Id,
                        description = workOrder.Description,
                        orderedBy = employee.FirstName + ' ' + employee.LastName,
                        product = product.Code,
                        orderDate = item.DateAdded,
                        dueDate = item.DueDate,
                        costPerItem = item.CostPerItem,
                        quantity = item.Quantity
                    };
                    view.status = (item.Complete) ? "Complete" : "Active";
                    workorderView.Add (view);

                }
                return workorderView;

            } catch (Exception) {
                return null;
            }

        }

        public IEnumerable<WorkOrderView> CreateWorkOrderViewList (IEnumerable<ProductionOrder> workOrder) {

            try {
                List<WorkOrderView> workorderView = new List<WorkOrderView> ();
                foreach (var order in workOrder) {
                    var employee = _employeeQuery.GetEmployeeById (order.OrderedBy);

                    foreach (var orderList in order.ProductionOrderList) {
                        var product = _productsQuery.GetProductById (orderList.ItemId);
                        WorkOrderView view = new WorkOrderView ();
                        view.id = order.Id;
                        view.description = order.Description;
                        view.orderedBy = employee.FirstName + ' ' + employee.LastName;
                        view.orderDate = orderList.DateAdded;
                        view.orderId = orderList.Id;
                        view.costPerItem = orderList.CostPerItem;
                        view.quantity = orderList.Quantity;
                        view.dueDate = orderList.DueDate;
                        view.product = product.Code;
                        view.status = (orderList.Complete) ? "Complete" : "Active";
                        workorderView.Add (view);
                    }

                }
                return workorderView;

            } catch (Exception) {
                return null;
            }

        }

        public WorkOrderView CreateWorkOrderView (ProductionOrderList workOrder) {

            try {
                var employee = _employeeQuery.GetEmployeeById (workOrder.ProductionOrder.OrderedBy);

                var product = _productsQuery.GetProductById (workOrder.ItemId);

                WorkOrderView view = new WorkOrderView () {
                    orderId = workOrder.ProductionOrderId,
                    id = workOrder.Id,
                    description = workOrder.ProductionOrder.Description,
                    orderedBy = employee.FirstName + ' ' + employee.LastName,
                    product = product.Code,
                    orderDate = workOrder.DateAdded,
                    dueDate = workOrder.DueDate,
                    costPerItem = workOrder.CostPerItem,
                    quantity = workOrder.Quantity
                };
                view.status = (workOrder.Complete) ? "Complete" : "Active";

                return view;

            } catch (Exception) {
                return null;
            }

        }

    }
}