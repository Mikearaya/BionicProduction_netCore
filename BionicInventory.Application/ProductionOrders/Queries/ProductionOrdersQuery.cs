/*
 * @CreateTime: Sep 10, 2018 8:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 30, 2018 5:44 PM
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
                                        orderedBy = $"{pro.ProductionOrder.Employee.FirstName} {pro.ProductionOrder.Employee.LastName}",
                                        orderId = pro.ProductionOrderId,
                                        product = pro.Item.Code,
                                        orderDate = pro.ProductionOrder.AddedOn,
                                        dueDate = pro.DueDate,
                                        total = pro.Quantity,
                                        client = (pro.PurchaseOrder != null) ?
                                        $"{pro.PurchaseOrder.PurchaseOrder.Client.FirstName} {pro.PurchaseOrder.PurchaseOrder.Client.LastName}" : "",
                                        type = (pro.PurchaseOrderId == null) ? "Work-to-Stock" : "Work-to-Order"
                                })
                        }).ToList ();

                    List<WorkOrderView> view = new List<WorkOrderView> ();

                    foreach (var item in x) {

                        WorkOrderView v = new WorkOrderView ();
                        v.id = item.id;

                        foreach (var r in item.status) {
                            var remaining = r.total - r.remaining;

                            v.status = (remaining == 0) ? "COMPLETE" : "IN-PROGRESS";
                            v.description = r.Description;
                            v.dueDate = r.dueDate;
                            v.orderDate = r.orderDate;
                            v.product = r.product;
                            v.quantity = (int) r.total;
                            v.client = r.client;
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

                        return _database.ProductionOrder.Include (p => p.ProductionOrderList).ToList ();

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

                public IEnumerable<WorkOrderView> GetPendingWorkOrders () {
                    return _database.PurchaseOrderDetail.Where (pOrder => pOrder.ProductionOrderList == null)
                        .Select (po => new WorkOrderView () {
                                id = po.Id,
                                description = "No Discription",
                                orderedBy = $"{po.PurchaseOrder.CreatedByNavigation.FirstName} {po.PurchaseOrder.CreatedByNavigation.LastName}",
                                            orderId = po.PurchaseOrderId,
                                            product = po.Item.Code,
                                            orderDate = po.DateAdded,
                                            dueDate = po.DueDate,
                                            quantity = (int) po.Quantity,
                                            client = (po.PurchaseOrder != null) ?
                                            $"{po.PurchaseOrder.Client.FirstName} {po.PurchaseOrder.Client.LastName}" : "",
                                            type = "Work-to-Order",
                                            status = "PENDING"

                                    }).ToList();
                            }
                        }
                }