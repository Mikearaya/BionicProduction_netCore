/*
 * @CreateTime: Sep 26, 2018 8:55 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 13, 2018 8:23 PM
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
        public CustomerOrderDetailView GetCustomerOrderDetail (uint id) {
                
    var salesOrders =   _database.PurchaseOrderDetail
        .Where(customerOrder => customerOrder.PurchaseOrderId == id)
                        .GroupBy(customerOrder => customerOrder.PurchaseOrderId)
                        .Select(order => new {
                            ID = order.Key.ToString(),
                            totalProducts = order.Count(),
                            totalPrice = order.Sum(price => price.PricePerItem * price.Quantity),
                            totalCost = order.Sum(itemCost => itemCost.Item.UnitCost * itemCost.Quantity),
                            totalQuantity = order.Sum(itemQuantity => itemQuantity.Quantity),

                            detail = order.Select(CO => new {
                                customerName = $"{CO.PurchaseOrder.Client.FirstName} {CO.PurchaseOrder.Client.LastName} ",
                                createdBy = $"{CO.PurchaseOrder.CreatedByNavigation} {CO.PurchaseOrder.CreatedByNavigation.LastName}",
                                dateAdded = CO.PurchaseOrder.DateAdded,
                                dateUpdated = CO.PurchaseOrder.DateUpdated,
                                description = CO.PurchaseOrder.Description,
                                pamentMethod = CO.PurchaseOrder.PaymentMethod,
                                uintCost = CO.Item.UnitCost,
                                id = CO.Id,
                                unitPrice = CO.PricePerItem,
                                productId = CO.Item.Id,
                                quantity = CO.Quantity,
                                productName = CO.Item.Name,
                                dueDate = CO.DueDate,
                                manufactureId = (CO.ProductionOrderList != null ) ? CO.ProductionOrderList.Id : 0,
                                productCode = CO.Item.Code,
                                status =  (CO.ProductionOrderList != null) ? CO.ProductionOrderList.FinishedProduct.Count() : -1,


                            }),


                        }).FirstOrDefault();  

                            CustomerOrderDetailView orderDetail = new CustomerOrderDetailView();

                            orderDetail.totalCost = salesOrders.totalCost;
                            orderDetail.totalPrice = salesOrders.totalPrice;
                            orderDetail.totalProducts = (uint) salesOrders.totalProducts;
                            orderDetail.totalQuantity = (uint) salesOrders.totalQuantity;
                            orderDetail.Id = salesOrders.ID;
                            
                            foreach (var orders in salesOrders.detail)
                            {
                                var status = " ";
                            if(orders.status < 0) {
                                status = "Pending";
                            } else if(orders.status == orders.quantity) {
                                    status = "Ready";
                            } else {
                                status = "In production";
                            }
                                orderDetail.customerName = orders.customerName;
                                orderDetail.createdBy = orders.createdBy;
                                orderDetail.description = orders.description;

                                orderDetail.paymentMethod = orders.pamentMethod;
                                orderDetail.orderItems.Add(new CustomerOrderItemsView(){
                                    id = orders.id.ToString(),
                                    quantity = (int) orders.quantity,
                                    productId = orders.productId,
                                    productName = orders.productName,
                                    productCode = orders.productCode,
                                    totalCost = orders.uintCost * orders.quantity,
                                    totalPrice = orders.unitPrice * orders.quantity,
                                    unitCost = orders.uintCost,
                                    unitPrice = orders.unitPrice,
                                    profit = (orders.unitPrice * orders.quantity) - (orders.uintCost * orders.quantity),
                                    dateAdded = (DateTime) orders.dateAdded,
                                    dateUpdated = (DateTime) orders.dateUpdated,
                                    dueDate = orders.dueDate,
                                    manufacturingOrderId = orders.manufactureId.ToString(),
                                    status = status


                                });                        
                            
                        }          

                return orderDetail;                            
                

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
                                customerName = CO.PurchaseOrder.Client.FullName(),
                                addedBy = CO.PurchaseOrder.CreatedByNavigation.FullName(),
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
                                salesOrder.description = item.description;
                                salesOrder.createdBy = item.addedBy;
                                salesOrder.customerName = item.customerName;
                                salesOrder.dateAdded = (DateTime) item.dateAdded;
                                salesOrder.dateUpdated = (DateTime) item.dateUpdated;
                                salesOrder.paymentMethod = item.pamentMethod;
                                sum += item.status;

                                
                            }

                            if(sum < 0) {
                                    salesOrder.status = "Pending";
                            } else if(sum == order.totalQuantity) {
                                    salesOrder.status = "Ready";
                            } else {
                                salesOrder.status = "In production";
                            }

                        salesView.Add(salesOrder);
                    }

            return salesView;

        }

        //TODO remove duplicate function
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