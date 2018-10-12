/*
 * @CreateTime: Sep 26, 2018 8:55 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 1, 2018 11:44 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.SalesOrders.Interfaces;
using BionicInventory.Application.SalesOrders.Models;
using BionicInventory.Domain.PurchaseOrders;
using BionicInventory.Domain.PurchaseOrders.PurchaseOrderDetails;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.SalesOrders.Queries {
    public class SalesOrderQuery : ISalesOrderQuery {
        private readonly IInventoryDatabaseService _database;
        private readonly ILogger<SalesOrderQuery> _logger;

        public SalesOrderQuery (IInventoryDatabaseService databse,
            ILogger<SalesOrderQuery> logger) {
            _database = databse;
            _logger = logger;
        }
        public IEnumerable<SalesOrderView> GetCustomerOrderDetail () {
                
            return _database.PurchaseOrderDetail.Select (sales => new SalesOrderView () {
                Id = sales.PurchaseOrderId,
                    CustomerName = $"{sales.PurchaseOrder.Client.FirstName} {sales.PurchaseOrder.Client.LastName}",
                    OrderCode = $"{sales.PurchaseOrder.Id}-{sales.Id}",
                    CreatedBy = $"{sales.PurchaseOrder.CreatedByNavigation.FullName()}",
                    Quantity = sales.Quantity,
                    Description = sales.PurchaseOrder.Description,
                    ItemCode = sales.Item.Code,
                    UnitPrice = (float) sales.PricePerItem,
                    paidAmount = (float) sales.PurchaseOrder.InitialPayment,  //+ sales.PurchaseOrder.Invoice.InvoicePayments.Sum(pay => pay.Amount),
                    remainingPayment = ((double) sales.PricePerItem * sales.Quantity) - sales.PurchaseOrder.InitialPayment,
                    totalPrice = (double) sales.PricePerItem * sales.Quantity,
                    OrderedOn = (DateTime) sales.DateAdded,
                    PaymentMethod = sales.PurchaseOrder.PaymentMethod,
                    Status = (sales.ProductionOrderList == null)  ?  "PENDING" : "IN-PRDUCTION",
                    DueDate = sales.DueDate
//TODO : Payment amount calculation 
            }).ToList ();

        }

 public IEnumerable<CustomerOrdersView> GetAllCustomerOrders () {
                
            var salesOrders =   _database.PurchaseOrderDetail
                        .GroupBy(customerOrder => customerOrder.PurchaseOrderId)
                        .Select(order => new {
                            ID = order.Key,
                            itemCount = order.Count(),
                            totalPrice = order.Sum(price => price.PricePerItem * price.Quantity),
                            totalCost = order.Sum(itemCost => itemCost.Item.UnitCost * itemCost.Quantity),
                            totalQuantity = order.Sum(itemQuantity => itemQuantity.Quantity),
                    
                            detail = order.Select(CO => new {
                                customerName = $"{CO.PurchaseOrder.Client.FirstName} {CO.PurchaseOrder.Client.LastName} ",
                                addedBy = $"{CO.PurchaseOrder.CreatedByNavigation} {CO.PurchaseOrder.CreatedByNavigation.LastName}",
                                dateAdded = CO.PurchaseOrder.DateAdded,
                                dateUpdated = CO.PurchaseOrder.DateUpdated,
                                description = CO.PurchaseOrder.Description,
                                pamentMethod = CO.PurchaseOrder.PaymentMethod,
                                status =  (CO.ProductionOrderList != null) ? CO.ProductionOrderList.FinishedProduct.Count() : -1,


                            }),


                        });
            List<CustomerOrdersView> salesView = new List<CustomerOrdersView>();

                    foreach (var order in salesOrders)
                    {
                    CustomerOrdersView    salesOrder = new CustomerOrdersView() {
                        Id = order.ID.ToString(),
                        totalCost = order.totalCost,
                        totalPrice = order.totalPrice,
                        totalQuantity = (uint) order.totalQuantity,
                        totalProducts = (uint) order.itemCount
                    };
                            var sum = 0;
                            foreach (var item in order.detail) 
                            {
                                salesOrder.Description = item.description;
                                salesOrder.CreatedBy = item.addedBy;
                                salesOrder.CustomerName = item.customerName;
                                salesOrder.DateAdded = (DateTime) item.dateAdded;
                                salesOrder.DateUpdated = (DateTime) item.dateUpdated;
                                salesOrder.PaymentMethod = item.pamentMethod;
                                sum += item.status;

                                
                            }

                            if(sum < 0) {
                                    salesOrder.Status = "PENDING";
                            } else if(sum == order.totalQuantity) {
                                    salesOrder.Status = "DONE";
                            } else {
                                salesOrder.Status = "IN PROGRESS";
                            }

                        salesView.Add(salesOrder);
                    }

            return salesView;

        }
        public PurchaseOrder GetSalesOrderById (uint id) {
            return _database.PurchaseOrder.Where (order => order.Id == id).Select (sales => new PurchaseOrder () {
                Id = sales.Id,
                    ClientId = sales.ClientId,
                    InitialPayment = sales.InitialPayment,
                    CreatedBy = sales.CreatedBy,
                    PaymentMethod = sales.PaymentMethod,
                    PurchaseOrderDetail = sales.PurchaseOrderDetail.Where (detail => detail.PurchaseOrderId == id).ToList ()
            }).FirstOrDefault ();
        }

        public PurchaseOrderDetail GetSalesOrderItemById(uint id)
        {
            return _database.PurchaseOrderDetail
                                .Where(order => order.Id == id)
                                .Select(orderItem => new PurchaseOrderDetail(){
                                    Id = orderItem.Id,
                                    PricePerItem = orderItem.PricePerItem,
                                    PurchaseOrderId = orderItem.PurchaseOrderId,
                                    ItemId = orderItem.ItemId,
                                    Quantity = orderItem.Quantity,
                                    DateAdded = orderItem.DateAdded,
                                    DateUpdated = orderItem.DateUpdated,
                                    DueDate = orderItem.DueDate
                                }).FirstOrDefault();
        }


    }
}