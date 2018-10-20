/*
 * @CreateTime: Sep 10, 2018 8:32 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 18, 2018 10:27 PM
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
using BionicInventory.Domain.ProductionOrders.ProductionOrderLists;

namespace BionicInventory.Application.ProductionOrders.Factories {
    public class WorkOrderFactory : IWorkOrdersFactory {
        private readonly IEmployeesQuery _employeeQuery;

        public IProductsQuery _productsQuery { get; }

        public WorkOrderFactory (IEmployeesQuery employeeQuery, IProductsQuery productsQuery) {
            _employeeQuery = employeeQuery;
            _productsQuery = productsQuery;
        }
        public ProductionOrderList CreateNewWorkOrder (NewWorkOrderDto newOrder) {

            try {
                
                var product = _productsQuery.GetProductById (newOrder.ItemId);
                
                ProductionOrderList productionOrder = new ProductionOrderList () {
                    Description = newOrder.Description,
                    OrderedBy = newOrder.OrderedBy,
                    ItemId = newOrder.ItemId,
                    CostPerItem = product.UnitCost,
                    Quantity = newOrder.Quantity,
                    DueDate = newOrder.DueDate,
                    Start = newOrder.Start,
                    PurchaseOrderId = newOrder.PurchaseOrderItemId

                };

                return productionOrder;

            } catch (Exception) {
                return null;
            }
        }

        public ProductionOrderList CreateUpdatedWorkOrder (UpdatedWorkOrderDto newOrder) {
            
            var product = _productsQuery.GetProductById (newOrder.ItemId);

            ProductionOrderList productionOrder = new ProductionOrderList () {
                Description = newOrder.Description,
                OrderedBy = newOrder.OrderedBy,
                Id = newOrder.Id,
                ItemId = newOrder.ItemId,
                CostPerItem = product.UnitCost,
                Quantity = newOrder.Quantity,
                DueDate = newOrder.DueDate,
                Start = newOrder.Start,
                
            };

            if(newOrder.PurchaseOrderItemId != 0) {
                productionOrder.PurchaseOrderId = newOrder.PurchaseOrderItemId;
            }


            return productionOrder;

        }

        public WorkOrderView CreateWorkOrderView (ProductionOrderList workOrder) {




                
                var employee = _employeeQuery.GetEmployeeById (workOrder.OrderedBy);
                var item = _productsQuery.GetProductById (workOrder.ItemId);
                ManufactureOrderView workorderView = new ManufactureOrderView () {
                    id = workOrder.Id,
                    description = workOrder.Description,
                    orderedBy = employee.FullName(),
                    product = item.Code,
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
                var product = _productsQuery.GetProductById (order.ItemId);
    
                    ManufactureOrderView view = new ManufactureOrderView ();
                    view.id = order.Id;
                    view.description = order.Description;
                    view.orderedBy = employee.FirstName + ' ' + employee.LastName;
                    view.orderDate = order.DateAdded;
                    view.quantity = (int) order.Quantity;
                    view.start = order.Start;
                    view.dueDate = order.DueDate;
                    view.product = product.Code;
                    workorderView.Add (view);

            }
            return workorderView;

        }

        public uint ExtractId(string id)
        {
            string[] words = id.Split('-');
        bool isNumerical = uint.TryParse(words[1], out uint orderId);

            return (isNumerical) ? orderId : 0;
        }

        public WorkOrderView CreateSingleWorkOrderView(ProductionOrderList workOrder)
        {
            throw new NotImplementedException();
        }
    }
}