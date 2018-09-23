/*
 * @CreateTime: Sep 10, 2018 8:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2018 11:10 PM
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

        public IEnumerable<WorkOrderView> GetAllActiveWorkOrders () {
            //TODO Implement GetAllActiveWorkOrder
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
                                total =  pro.Quantity
                        })
                }).ToList ();
    
            List<WorkOrderView> view = new List<WorkOrderView> ();
            foreach (var item in x) {

                WorkOrderView v = new WorkOrderView ();
                v.id = item.id;

                foreach (var r in item.status) {
                    v.remaining = (int) r.remaining;
                    v.completed = (int) r.total - (int) r.remaining;
                    v.description = r.Description;
                    v.dueDate = r.dueDate;
                    v.orderDate = r.orderDate;
                    v.product = r.product;
                    v.quantity = (int) r.total;
                    v.orderedBy = r.orderedBy;
                    v.orderId = r.orderId;
                    v.status = (v.completed == v.quantity) ? "Completed" : "Active";
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
    }
}