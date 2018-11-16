using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Products.Interfaces.Booking;
using BionicInventory.Application.Products.Models.BookingModel;
using BionicInventory.Domain.FinishedProducts;
using BionicInventory.Domain.Items;
using BionicInventory.Domain.ProductionOrders.ProductionOrderLists;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Products.Queries.booking {
    public class StockBookingQuery : IStockBookingQuery {
        private readonly ILogger<StockBookingQuery> _logger;
        private readonly IInventoryDatabaseService _database;

        public StockBookingQuery (IInventoryDatabaseService database,
            ILogger<StockBookingQuery> logger) {
            _logger = logger;
            _database = database;
        }
        public CustomerOrderBookings GetCustomerOrderBookings (uint id) {

            var bookingDetail = (from pro in _database.Item 
            join co in _database.PurchaseOrderDetail on pro.Id equals co.ItemId 
            where co.PurchaseOrderId == id select new {
                customerOrderItemId = co.Id,
                    customerOrderId = co.PurchaseOrderId,
                    needed = co.Quantity,
                    available = pro.ProductionOrderList.Where (mo => mo.PurchaseOrder == null)
                    .Sum (mo => mo.FinishedProduct.Count (f => f.BookedStockItems == null && f.ShipmentDetail == null)),
                    bookedM = pro.ProductionOrderList.Where (mo => mo.PurchaseOrderId == co.Id).Sum (d => d.Quantity),
                    bookedF = pro.ProductionOrderList.Sum (mo => mo.FinishedProduct
                        .Count (f => f.ShipmentDetail == null && (mo.PurchaseOrderId == co.Id || f.BookedStockItems.BookedFor == co.Id))),
                    productName = $"{pro.Name} ({pro.Code})",
                    productId = pro.Id,
                    customerName = co.PurchaseOrder.Client.FullName (),
            }).GroupBy (g => g.customerOrderItemId).Select (booking => new {
                statistics = booking.Select (f => new {
                    available = f.available,
                        booked = f.bookedM + f.bookedF,
                        needed = f.needed,
                        customerOrderItemId = f.customerOrderItemId,
                        customerOrderId = f.customerOrderId,
                        item = f.productName,
                        productId = f.productId,
                        customerName = f.customerName,

                })
            });

            CustomerOrderBookings orderBookingStat = new CustomerOrderBookings ();

            foreach (var stat in bookingDetail) {

                foreach (var item in stat.statistics) {
                    orderBookingStat.id = item.customerOrderId;
                    orderBookingStat.customer = item.customerName;

                    orderBookingStat.orderItems.Add (new BookedOrderItemDetail () {
                        id = item.customerOrderItemId,
                            productName = item.item,
                            neededAmount = item.needed,
                            bookedAmount = item.booked,
                            inStock = item.available,
                            availableAmount = item.available,
                            afterBooking = item.available - (item.needed - item.booked),
                            remainingAmount = (item.needed > item.booked) ? item.needed - item.booked : 0
                    });
                }
                //TODO: filter inStock and available value for in manufacture order and ready to go

            }
            return orderBookingStat;
        }

        private IQueryable<FinishedProduct> availableStockItemFormCustomerOrder (uint customerOrderId) {
            return (from pro in _database.FinishedProduct 
            join mo in _database.ProductionOrderList on pro.OrderId equals mo.Id
            join co in _database.PurchaseOrderDetail on mo.ItemId equals co.ItemId 
            where co.Id == customerOrderId &&
                    pro.BookedStockItems == null &&
                    pro.ShipmentDetail == null &&
                    (pro.Order.PurchaseOrder == null)

                    select new FinishedProduct () {
                        Id = pro.Id,
                            OrderId = pro.OrderId,
                            DateAdded = pro.DateAdded,
                            DateUpdated = pro.DateUpdated,
                            SubmittedBy = pro.SubmittedBy,
                            Quantity = pro.Quantity
                    })
                .OrderByDescending (d => d.DateAdded).AsQueryable ();
        }

        public IList<FinishedProduct> GetAvailableCustomerOrderItem (uint customerOrderId) {

            return availableStockItemFormCustomerOrder (customerOrderId)
                .ToList ();
        }

        public IList<FinishedProduct> AvailableStockItemsForOrder (int quantity, uint customerOrderId) {
            return availableStockItemFormCustomerOrder (customerOrderId)
                .Take (quantity)
                .ToList ();
        }

    }

}

public class bookingStatistics {
    public float availableAmount { get; set; }
    public float inStock { get; set; }
    public float bookedAmount { get; set; }
    public float afterBooking { get; set; }
    public float needed { get; set; }
    public float remaining { get; set; }

    public bookingStatistics Accumilate (Item item) {
        inStock = item.ProductionOrderList.Sum (m => m.FinishedProduct.Where (f => f.ShipmentDetail == null).Count ());
        bookedAmount = item.ProductionOrderList.Sum (m => m.FinishedProduct.Where (f => f.ShipmentDetail == null && (m.PurchaseOrder != null || f.BookedStockItems != null)).Count ());
        return this;
    }

    public bookingStatistics Compute () {
        return this;
    }
}

/*var 

                    return boo; */