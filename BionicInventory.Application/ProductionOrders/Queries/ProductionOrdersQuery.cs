/*
 * @CreateTime: Sep 10, 2018 8:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 23, 2018 10:21 PM
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
                        production => production.Quantity > production.FinishedProduct
                        .Where (fin => fin.OrderId == production.Id).Count ()
                    )
                    .Select (orders => new ActiveOrdersView {
                        id = orders.Id,
                            dueDate = orders.DueDate,
                            total = orders.Quantity,
                            remaining = (int) orders.Quantity - orders.FinishedProduct.Where (fin => fin.OrderId == orders.Id).Count ()
                    })
                    .OrderByDescending (req => req.id)
                    .ToList ();

            }
            public IEnumerable<WorkOrderView> GetWorkOrdersStatus () {

                var x = _database.ProductionOrderList.GroupBy (po => po.Id)
                    .Select (production => new {
                        id = production.Key,
                            status = production.Select (pro => new {
                                completed = pro.FinishedProduct.Where (fin => fin.OrderId == production.Key).Count (),
                                    totalCost = pro.CostPerItem * pro.Quantity,
                                    Description = pro.Description,
                                    orderedBy = $"{pro.OrderedByNavigation.FirstName} {pro.OrderedByNavigation.LastName}",
                                    start = pro.Start,
                                    productName = pro.Item.Name,
                                    product = pro.Item.Code,
                                    orderDate = pro.DateAdded,
                                    dueDate = pro.DueDate,
                                    total = pro.Quantity,
                                    customer = (pro.PurchaseOrder != null) ? pro.PurchaseOrder.PurchaseOrder.Client.FullName () : "",
                                    type = (pro.PurchaseOrderId == null) ? "Work-to-Stock" : "Work-to-Order"
                            })
                    })

                    .OrderByDescending (req => req.id)
                    .ToList ();

                List<WorkOrderView> view = new List<WorkOrderView> ();

                foreach (var item in x) {

                    ManufactureOrderView v = new ManufactureOrderView ();
                    v.id = item.id;

                    foreach (var r in item.status) {
                        var remaining = r.total - r.completed;

                        if (r.completed == 0) {
                            v.status = "QUEUED";
                        } else if (r.completed > 0 && r.total > r.completed) {
                            v.status = "IN-PROGRESS";
                        } else if (r.completed == r.total) {
                            v.status = "COMPLETED";
                        } else if (r.completed > r.total) {
                            v.status = "OVER-MADE";
                        }
                        v.cost = r.totalCost;
                        v.description = r.Description;
                        v.dueDate = r.dueDate;
                        v.orderDate = r.orderDate;
                        v.start = r.start;
                        v.product = r.product;
                        v.productName = r.productName;
                        v.quantity = (int) r.total;
                        v.customer = r.customer;
                        v.orderedBy = r.orderedBy;
                        v.type = r.type;
                    }

                    view.Add (v);

                }

                return view;

            }

            public IEnumerable<ProductionOrderList> GetAllWorkOrders () {
                try {

                    return _database.ProductionOrderList.AsNoTracking ().ToList ();

                } catch (Exception) {
                    return null;
                }
            }

            public IEnumerable<ProductionOrderList> GetCompletedWorkOrders () {
                //TODO Implement GetCompleteWorkOrders
                throw new System.NotImplementedException ();
            }

            public ProductionOrderList GetWorkOrderById (uint id) {

                try {

                    return _database.ProductionOrderList.FirstOrDefault (order => order.Id == id);

                } catch (Exception) {
                    return null;
                }
            }

            public WorkOrderView GetWorkOrderItemById (uint id) {

                return _database.ProductionOrderList.Where (item => item.Id == id)
                    .Select (order => new WorkOrderView () {
                        id = order.Id,
                            orderedBy = order.OrderedByNavigation.FullName (),
                            orderedById = order.OrderedBy,
                            description = order.Description,
                            cost = (order.CostPerItem * (int) order.Quantity),
                            productName = order.Item.Name,
                            productId = order.Item.Id,
                            start = order.Start,
                            product = order.Item.Code,
                            dueDate = order.DueDate,
                            orderDate = order.DateAdded,
                            quantity = (int) order.Quantity,
                            customer = (order.PurchaseOrder != null) ? order.PurchaseOrder.PurchaseOrder.Client.FullName () : "",
                            salesOrderItemId = order.PurchaseOrderId

                    }).FirstOrDefault ();

            }

            public WorkOrderView GetPendingWorkOrder (uint manufactureRequestId = 0) {

                return _database.PurchaseOrderDetail.Where (pOrder => pOrder.ProductionOrderList == null)
                    .Where (request => request.Id == manufactureRequestId && request.PurchaseOrder.OrderStatus.ToUpper () == "CONFIRMED")
                    .OrderByDescending (req => req.Id)
                    .Select (po => new PendingOrdersView () {
                        salesOrderItemId = po.Id,
                            description = po.PurchaseOrder.Description,
                            salesManId = po.PurchaseOrder.CreatedBy,
                            salesMan = po.PurchaseOrder.CreatedByNavigation.FullName (),
                            salesOrderId = po.PurchaseOrderId,
                            product = po.Item.Code,
                            productId = po.Item.Id,
                            productName = po.Item.Name,
                            orderDate = po.DateAdded,
                            dueDate = po.DueDate,
                            quantity = (int) po.Quantity,
                            customer = (po.PurchaseOrder != null) ? po.PurchaseOrder.Client.FullName () : "",

                    })
                    .OrderByDescending (req => req.salesOrderId)
                    .FirstOrDefault ();

            }

            public IEnumerable<WorkOrderView> GetPendingWorkOrders () {
                var workRequests = _database.PurchaseOrderDetail
                        .Where (pOrder => pOrder.PurchaseOrder.OrderStatus.ToUpper() == "CONFIRMED" && pOrder.ProductionOrderList == null &&
                            (pOrder.BookedStockItems == null || pOrder.BookedStockItems.Count () <   pOrder.Quantity))
                    .GroupBy (request => request.PurchaseOrder.Id)

                    .Select (customerOrder => new {
                        Id = customerOrder.Key,
                            totalItems = customerOrder.Count (),
                            quantity = customerOrder.Sum (order => order.Quantity) - customerOrder.Sum (order => order.BookedStockItems.Count()),
                            manufactureRequests = customerOrder.Select (po => new PendingOrdersView () {
                                description = po.PurchaseOrder.Description,
                                    salesManId = po.PurchaseOrder.CreatedBy,
                                    salesMan = po.PurchaseOrder.CreatedByNavigation.FullName (),
                                    salesOrderId = po.PurchaseOrderId,
                                    salesOrderItemId = po.Id,
                                    productName = po.Item.Name,
                                    orderDate = po.DateAdded,
                                    customer = (po.PurchaseOrder != null) ? po.PurchaseOrder.Client.FullName () : "",

                            }).OrderByDescending (req => req.salesOrderId)
                    });

                    List<PendingOrdersView> requestedView = new List<PendingOrdersView> ();
                    foreach (var item in workRequests) {

                        foreach (var request in item.manufactureRequests) {
                            request.quantity = (int) item.quantity;
                            request.itemCount = item.totalItems;
                            requestedView.Add (request);
                            break;
                        }
                    }
                    return requestedView;
                }

                public bool saleOrderProductionExits (uint id) {
                    var order = _database.ProductionOrderList.Where (orders => orders.PurchaseOrderId == id)
                        .Select (result => new ProductionOrderList () {
                            Id = result.Id
                        }).FirstOrDefault ();

                    return (order == null) ? false : true;
                }
            }
        }