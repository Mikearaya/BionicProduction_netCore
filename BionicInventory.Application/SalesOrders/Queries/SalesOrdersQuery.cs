/*
 * @CreateTime: Sep 26, 2018 8:55 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 4, 2018 9:05 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.SalesOrders.Interfaces;
using BionicInventory.Application.SalesOrders.Models;
using BionicInventory.Application.SalesOrders.Models.Booking;
using BionicInventory.Domain.CustomerOrders;
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
        public CustomerOrderDetailView GetCustomerOrderItem (uint id) {

            var salesOrders = _database.CustomerOrderItem
                .Where (customerOrder => customerOrder.CustomerOrderId == id)
                .OrderByDescending (req => req.CustomerOrderId)
                .GroupBy (customerOrder => customerOrder.CustomerOrderId)
                .Select (order => new {
                    ID = order.Key,
                        totalProducts = order.Count (),
                        totalPrice = order.Sum (price => price.PricePerItem * price.Quantity),
                        totalCost = order.Sum (itemCost => itemCost.Item.UnitCost * itemCost.Quantity),
                        totalQuantity = order.Sum (itemQuantity => itemQuantity.Quantity),

                        detail = order.Select (CO => new {
                            customerName = CO.CustomerOrder.Client.FullName,
                                createdBy = CO.CustomerOrder.CreatedByNavigation.FullName (),
                                dateAdded = CO.CustomerOrder.DateAdded,
                                dateUpdated = CO.CustomerOrder.DateUpdated,
                                description = CO.CustomerOrder.Description,
                                status = CO.CustomerOrder.OrderStatus,
                                createdOn = CO.CustomerOrder.DateAdded,
                                deliveryDaye = CO.CustomerOrder.DueDate,
                                uintCost = CO.Item.UnitCost,
                                id = CO.Id,
                                unitPrice = CO.PricePerItem,
                                productId = CO.Item.Id,
                                quantity = CO.Quantity,
                                productName = CO.Item.Name,
                                dueDate = CO.DueDate,
                                //           manufactureId = (uint?) CO.ProductionOrderList.Id,
                                productCode = CO.Item.Code

                        }),

                }).FirstOrDefault ();

            CustomerOrderDetailView orderDetail = new CustomerOrderDetailView ();

            orderDetail.totalCost = salesOrders.totalCost;
            orderDetail.totalPrice = salesOrders.totalPrice;
            orderDetail.totalProducts = (uint) salesOrders.totalProducts;
            orderDetail.totalQuantity = (uint) salesOrders.totalQuantity;
            orderDetail.id = salesOrders.ID;

            foreach (var orders in salesOrders.detail) {
                var status = orders.status;
                orderDetail.status = orders.status;
                orderDetail.customerName = orders.customerName;
                orderDetail.createdBy = orders.createdBy;
                orderDetail.description = orders.description;

                orderDetail.createdOn = orders.createdOn;
                orderDetail.deliveryDate = orders.deliveryDaye;
                orderDetail.orderItems.Add (new CustomerOrderItemsView () {
                    id = orders.id,
                        quantity = (int) orders.quantity,
                        productId = orders.productId,
                        productName = orders.productName,
                        productCode = orders.productCode,
                        totalCost = orders.uintCost * orders.quantity,
                        totalPrice = orders.unitPrice * orders.quantity,
                        unitCost = orders.uintCost,
                        unitPrice = orders.unitPrice,
                        profit = (orders.unitPrice * orders.quantity) - (orders.uintCost * orders.quantity),
                        dateAdded = orders.dateAdded,
                        dateUpdated = orders.dateUpdated,
                        dueDate = orders.dueDate,
                        //       manufacturingOrderId = orders.manufactureId,
                        status = status

                });

            }

            return orderDetail;

        }

        public IEnumerable<CustomerOrdersView> GetAllCustomerOrders () {

            var salesOrders = _database.CustomerOrder
                .GroupBy (customerOrder => customerOrder.Id)
                .Select (order => new {
                    ID = order.Key,
                        itemCount = order.Count (),
                        totalPrice = order.Sum (price => price.CustomerOrderItem.Sum (d => d.PricePerItem * (double?) d.Quantity)),
                        //         totalCost = order.Sum (itemCost => itemCost.CustomerOrderItem.Sum (c => c.ProductionOrderList.CostPerItem * (double?) c.Quantity)),
                        totalQuantity = order.Sum (q => q.CustomerOrderItem.Sum (itemQuantity => itemQuantity.Quantity)),
                        invoicedAmount = order.Sum (i => i.Invoice.Sum (o => o.InvoiceDetail.Sum (id => (double?) id.Quantity * id.UnitPrice))),
                        invoicePaid = order.Sum (i => i.Invoice.Sum (o => o.InvoicePayments.Sum (id => id.Amount))),
                        totalShipment = order.Sum (p => p.Shipment.Sum (s => s.ShipmentDetail.Count ())),
                        //       inProductionAmount = order.Sum (o => o.CustomerOrderItem.Sum (d => d.ProductionOrderList.Quantity)),
                        bookedQuantity = order.Sum (o => o.CustomerOrderItem.Sum (b => b.BookedStockItems.Count ())),
                        detail = order.Select (CO => new {
                            customerName = CO.Client.FullName,
                                addedBy = CO.CreatedByNavigation.FullName (),
                                dateAdded = CO.DateAdded,
                                dateUpdated = CO.DateUpdated,
                                description = CO.Description,
                                orderStatus = CO.OrderStatus,

                        })

                }).OrderByDescending (req => req.ID);
            List<CustomerOrdersView> salesView = new List<CustomerOrdersView> ();

            foreach (var order in salesOrders) {
                CustomerOrdersView salesOrder = new CustomerOrdersView () {
                    id = order.ID,
                    //   totalCost = order.totalCost,
                    totalPrice = order.totalPrice,
                    totalQuantity = (uint) order.totalQuantity,
                    totalProducts = (uint) order.itemCount,
                    //     profit = order.totalPrice - order.totalCost,
                    invoiceStatus = IdentifyInvoiceStatus (order.totalQuantity, order.invoicedAmount),
                    paymentStatus = IdentityPaymentStatus (order.totalPrice, order.invoicePaid)
                };
                //            var sum = order.bookedQuantity + order.inProductionAmount;
                var orderStatus = "";

                foreach (var item in order.detail) {
                    salesOrder.description = item.description;
                    salesOrder.createdBy = item.addedBy;
                    salesOrder.customerName = item.customerName;
                    salesOrder.dateAdded = (DateTime) item.dateAdded;
                    salesOrder.dateUpdated = (DateTime) item.dateUpdated;
                    salesOrder.status = item.orderStatus;
                    orderStatus = item.orderStatus;

                }

         //       salesOrder.status = IdentifyOrderStatus (orderStatus, sum, order.totalQuantity);

                salesView.Add (salesOrder);
            }

            return salesView;

        }

        private string IdentifyOrderStatus (string status, double? totalBookedItems, double? orderQuantity) {
            if (totalBookedItems == 0 && status.ToUpper () == "CONFIRMED") {
                return "Pending";
            } else if (totalBookedItems == orderQuantity) {
                return "Ready for Shipment";
            } else if (status.ToUpper () != "CONFIRMED") {
                return "Confirmed";
            } else {
                return "In production";
            }

        }

        private string IdentityPaymentStatus (double? totalPrice, double? paidAmount) {
            double? paidPercent = (paidAmount / totalPrice) * 100;

            if (paidPercent == 100) {
                return "Paid";
            } else if (paidAmount > 0) {
                return $"Partially Paid {paidPercent} %";
            } else {
                return "Not Paid";
            }
        }

        private string IdentifyInvoiceStatus (double? orderQuantity, double? invoicedQuantity) {

            double? invoicedPercent = (invoicedQuantity / orderQuantity) * 100;

            if (invoicedPercent == 100) {
                return "Invoiced";
            } else if (invoicedPercent > 0) {
                return $"Partially Invoiced {invoicedPercent} %";
            } else {
                return "Not Invoiced";
            }
        }

        //TODO remove duplicate function
        public CustomerOrder GetSalesOrderById (uint id) {
            return _database.CustomerOrder
                .Where (order => order.Id == id)
                .Select (co => new CustomerOrder () {
                    Id = co.Id,
                        ClientId = co.ClientId,
                        CreatedBy = co.CreatedBy,
                        OrderStatus = co.OrderStatus,
                        Description = co.Description,
                        DateAdded = co.DateAdded,
                        DateUpdated = co.DateAdded,
                        CustomerOrderItem = co.CustomerOrderItem,
                        Shipment = co.Shipment
                }).FirstOrDefault ();
        }

        public CustomerOrderItem GetSalesOrderItemById (uint id) {
            return _database.CustomerOrderItem
                .Where (order => order.Id == id)
                .Select (orderItem => new CustomerOrderItem () {
                    Id = orderItem.Id,
                        PricePerItem = orderItem.PricePerItem,
                        CustomerOrderId = orderItem.CustomerOrderId,
                        ItemId = orderItem.ItemId,
                        Quantity = orderItem.Quantity,
                        DateAdded = orderItem.DateAdded,
                        DateUpdated = orderItem.DateUpdated,
                        DueDate = orderItem.DueDate
                }).FirstOrDefault ();
        }

        public uint GetTotalBookedOrder (uint customerOrderItemId) {
            var book = _database.CustomerOrderItem
                .Where (co => co.Id == customerOrderItemId)
                .Select (co => new {
                    Id = co.Id,
                        Required = co.Quantity,
                        Booked = co.BookedStockItems.Count ()

                }).FirstOrDefault ();

            return (uint) book.Booked;

        }

        public CustomerOrderDetailView GetCustomerOrderDetail (uint id) {
            throw new NotImplementedException ();
        }
    }

}