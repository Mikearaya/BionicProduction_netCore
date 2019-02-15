/*
 * @CreateTime: Sep 10, 2018 8:32 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 8:34 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BionicInventory.Application.Employees.Interfaces;
using BionicInventory.Application.ProductionOrders.Iterfaces;
using BionicInventory.Application.ProductionOrders.Models;
using BionicInventory.Application.Products.Interfaces;
using BionicInventory.Domain.ProductionOrders;

namespace BionicInventory.Application.ProductionOrders.Factories {
    public class WorkOrderFactory : IWorkOrdersFactory {
        private readonly IEmployeesQuery _employeeQuery;
        public WorkOrderFactory (IEmployeesQuery employeeQuery) {
            _employeeQuery = employeeQuery;
        }
        public ProductionOrderList CreateNewWorkOrder (NewWorkOrderDto newOrder) {

            try {

                ProductionOrderList productionOrder = new ProductionOrderList () {
                    Description = newOrder.Description,
                    OrderedBy = newOrder.OrderedBy,
                    ItemId = newOrder.ItemId,
                    Quantity = newOrder.Quantity,
                    DueDate = newOrder.DueDate,
                    Start = newOrder.Start

                };
/* 
                if (newOrder.PurchaseOrderItemId != 0) {
                    productionOrder.CustomerOrderItemId = newOrder.PurchaseOrderItemId;
                } */

                return productionOrder;

            } catch (Exception) {
                return null;
            }
        }

        public ProductionOrderList CreateUpdatedWorkOrder (UpdatedWorkOrderDto newOrder) {

            ProductionOrderList productionOrder = new ProductionOrderList () {
                Description = newOrder.Description,
                OrderedBy = newOrder.OrderedBy,
                Id = newOrder.Id,
                ItemId = newOrder.ItemId,
                Quantity = newOrder.Quantity,
                DueDate = newOrder.DueDate,
                Start = newOrder.Start,

            };

     /*        if (newOrder.PurchaseOrderItemId != 0) {
                productionOrder.CustomerOrderItemId = newOrder.PurchaseOrderItemId;
            } */

            return productionOrder;

        }

        public WorkOrderView CreateWorkOrderView (ProductionOrderList workOrder) {

            var employee = _employeeQuery.GetEmployeeById (workOrder.OrderedBy);
            ManufactureOrderView workorderView = new ManufactureOrderView () {
                id = workOrder.Id,
                description = workOrder.Description,
                orderedBy = employee.FullName (),
                start = workOrder.Start,
                orderDate = workOrder.DateAdded,
                dueDate = workOrder.DueDate,
                quantity = (int) workOrder.Quantity
            };

            return workorderView;

        }

        public IEnumerable<WorkOrderView> CreateWorkOrderViewList (IEnumerable<ProductionOrderList> workOrder) {

            List<ManufactureOrderView> workorderView = new List<ManufactureOrderView> ();
            foreach (var order in workOrder) {
                var employee = _employeeQuery.GetEmployeeById (order.OrderedBy);

                ManufactureOrderView view = new ManufactureOrderView ();
                view.id = order.Id;
                view.description = order.Description;
                view.orderedBy = employee.FirstName + ' ' + employee.LastName;
                view.orderDate = order.DateAdded;
                view.quantity = (int) order.Quantity;
                view.start = order.Start;
                view.dueDate = order.DueDate;
                workorderView.Add (view);

            }
            return workorderView;

        }

        public uint ExtractId (string id) {
            string[] words = id.Split ('-');
            bool isNumerical = uint.TryParse (words[1], out uint orderId);

            return (isNumerical) ? orderId : 0;
        }

        public WorkOrderView CreateSingleWorkOrderView (ProductionOrderList workOrder) {
            throw new NotImplementedException ();
        }

        public NewWorkOrderDto CreateCustomerOrderDto (uint customerOrderId, uint itemId, uint quantity, DateTime startDate, DateTime endDate, uint bookedBy, string description = "") {
            NewWorkOrderDto work = new NewWorkOrderDto () {
            PurchaseOrderItemId = customerOrderId,
            OrderedBy = bookedBy,
            ItemId = itemId,
            Quantity = quantity,
            DueDate = endDate,
            Start = startDate
            };

            if (description.Trim () != "") {
                work.Description = description.Trim ();
            }
            return work;
        }
    }
}