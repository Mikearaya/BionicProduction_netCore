/*
 * @CreateTime: Sep 10, 2018 8:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 9, 2018 11:19 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.ProductionOrders.Iterfaces;
using BionicInventory.Application.ProductionOrders.Models;
using BionicInventory.Domain.ProductionOrders;
using BionicInventory.Domain.ProductionOrders.ProductionOrderLists;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.ProductionOrders.Queries {
    public class WorkOrdersQuery : IWorkOrdersQuery {
        private readonly IInventoryDatabaseService _database;

        public WorkOrdersQuery (IInventoryDatabaseService database) {
            _database = database;
        }

        public IEnumerable<ActiveOrdersView> GetActiveWorkOrders () {
            return _database.ProductionOrderList.Where (
                production => production.Quantity > production.FinishedProduct.Where (fin => fin.OrderId == production.Id).Count ()
            ).Select (orders => new ActiveOrdersView {
                id = orders.Id,
                    orderId = orders.ProductionOrderId,
                    dueDate = orders.DueDate,
                    total = orders.Quantity,
                    remaining = (int) orders.Quantity - orders.FinishedProduct.Where (fin => fin.OrderId == orders.Id).Count ()
            }).ToList ();

        }
        public IEnumerable<WorkOrderView> GetWorkOrdersStatus () {

            var x = _database.ProductionOrderList.GroupBy (po => po.Id)
                .Select (production => new {
                    id = production.Key,
                        status = production.Select (pro => new {
                            remaining = pro.Quantity - pro.FinishedProduct.Where (fin => fin.OrderId == production.Key).Count (),

                                Description = pro.ProductionOrder.Description,
                                orderedBy = $"{pro.ProductionOrder.OrderedByNavigation.FirstName} {pro.ProductionOrder.OrderedByNavigation.LastName}",
                                orderId = pro.ProductionOrderId,
                                product = pro.Item.Code,
                                orderDate = pro.ProductionOrder.AddedOn,
                                dueDate = pro.DueDate,
                                total = pro.Quantity,
                                customer = (pro.PurchaseOrder != null) ?
                                $"{pro.PurchaseOrder.PurchaseOrder.Client.FirstName} {pro.PurchaseOrder.PurchaseOrder.Client.LastName}" : "",
                                type = (pro.PurchaseOrderId == null) ? "Work-to-Stock" : "Work-to-Order"
                        })
                }).ToList ();

            List<WorkOrderView> view = new List<WorkOrderView> ();

            foreach (var item in x) {

                ManufactureOrderView v = new ManufactureOrderView ();
                v.id = item.id;

                foreach (var r in item.status) {
                    var remaining = r.total - r.remaining;

                    v.status = (remaining == 0) ? "COMPLETE" : "IN-PROGRESS";
                    v.description = r.Description;
                    v.dueDate = r.dueDate;
                    v.orderDate = r.orderDate;
                    v.product = r.product;
                    v.quantity = (int) r.total;
                    v.customer = r.customer;
                    v.orderedBy = r.orderedBy;
                    v.orderId = r.orderId;
                    v.type = r.type;
                }

                view.Add (v);

            }

            return view;

        }

        public IEnumerable<ProductionOrder> GetAllWorkOrders () {
            try {

                return _database.ProductionOrder.Include (p => p.ProductionOrderList).AsNoTracking().ToList ();

            } catch (Exception) {
                return null;
            }
        }

        public IEnumerable<ProductionOrder> GetCompletedWorkOrders () {
            //TODO Implement GetCompleteWorkOrders
            throw new System.NotImplementedException ();
        }

        public ProductionOrder GetWorkOrderById (uint id) {

            try {

                return _database.ProductionOrder.Where (order => order.Id == id).Include (order => order.ProductionOrderList).FirstOrDefault ();

            } catch (Exception) {
                return null;
            }
        }

        public ProductionOrderList GetWorkOrderItemById (uint id) {
            try {

                return _database.ProductionOrderList.FirstOrDefault (item => item.Id == id);

            } catch (Exception) {
                return null;
            }
        }

        public IEnumerable<WorkOrderView> GetPendingWorkOrders (uint manufactureRequestId = 0) {
            return _database.PurchaseOrderDetail.Where (pOrder => pOrder.ProductionOrderList == null)
                .Where (request => request.PurchaseOrder.Id == manufactureRequestId)
                .Select (po => new PendingOrdersView () {
                        salesOrderItemId = po.Id,
                        description = po.PurchaseOrder.Description,
                        orderedBy = $"{po.PurchaseOrder.CreatedByNavigation.FirstName} {po.PurchaseOrder.CreatedByNavigation.LastName}",
                        salesOrderId = po.PurchaseOrderId,
                        product = po.Item.Code,
                        productId = po.Item.Id,
                        productName = po.Item.Name,
                        orderDate = po.DateAdded,
                        dueDate = po.DueDate,
                        quantity = (int) po.Quantity,
                        customer = (po.PurchaseOrder != null) ?
                        $"{po.PurchaseOrder.Client.FirstName} {po.PurchaseOrder.Client.LastName}" : "",

                }).ToList ();

        }

        public IEnumerable<WorkOrderView> GetPendingWorkOrders () {
            return _database.PurchaseOrderDetail.Where (pOrder => pOrder.ProductionOrderList == null)
                .Select (po => new PendingOrdersView () {
                    salesOrderItemId = po.Id,
                        description = po.PurchaseOrder.Description,
                        orderedBy = $"{po.PurchaseOrder.CreatedByNavigation.FirstName} {po.PurchaseOrder.CreatedByNavigation.LastName}",
                        salesOrderId = po.PurchaseOrderId,
                        product = po.Item.Code,
                        productId = po.Item.Id,
                        productName = po.Item.Name,
                        orderDate = po.DateAdded,
                        dueDate = po.DueDate,
                        quantity = (int) po.Quantity,
                        customer = (po.PurchaseOrder != null) ?
                        $"{po.PurchaseOrder.Client.FirstName} {po.PurchaseOrder.Client.LastName}" : "",

                }).ToList ();
        }

        public bool saleOrderProductionExits(uint id)
        {
            var order = _database.ProductionOrderList.Where(orders => orders.PurchaseOrderId == id)
                    .Select(result => new ProductionOrderList() {
                        Id = result.Id
                    }).FirstOrDefault();

            return (order == null) ? false : true;
        }
    }
}