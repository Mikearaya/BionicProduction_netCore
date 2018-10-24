


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Products.Interfaces.Booking;
using BionicInventory.Application.Products.Models.BookingModel;

using BionicInventory.Domain.Items;
using BionicInventory.Domain.ProductionOrders.ProductionOrderLists;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Products.Queries.booking {
    public class StockBookingQuery : IStockBookingQuery
    {
        private readonly ILogger<StockBookingQuery> _logger;
        private readonly IInventoryDatabaseService _database;

        public StockBookingQuery(IInventoryDatabaseService database,
                            ILogger<StockBookingQuery> logger) {
                                _logger = logger;
                                _database = database;
        }
        public CustomerOrderBookings GetCustomerOrderBookings(uint id)
        {

            var bookingDetail = (from pro in _database.Item
                join co in _database.PurchaseOrderDetail on pro.Id equals co.ItemId
                where co.PurchaseOrderId == id
                select new {
                    customerOrderItemId = co.Id,
                    customerOrderId = co.PurchaseOrderId,
                    needed = co.Quantity,
                    available = pro.ProductionOrderList.Where(mo => mo.PurchaseOrderId == null).Sum(mo => mo.FinishedProduct.Count(f => f.BookedStockItems == null && f.Sales == null)),
                    booked  = pro.ProductionOrderList.Where(mo => mo.PurchaseOrderId == co.Id)
                    .Sum(mo => mo.Quantity + mo.FinishedProduct
                    .Count(f => f.Sales == null && f.OrderId == mo.Id)),
                    productName = $"{pro.Name} ({pro.Code})",
                    customerName = co.PurchaseOrder.Client.FullName(),
                }).GroupBy(g => g.customerOrderItemId).Select(booking => new {
                    statistics = booking.Select(f => new {
                        available = f.available,
                        booked = f.booked,
                        needed = f.needed,
                        customerOrderItemId = f.customerOrderItemId,
                        customerOrderId = f.customerOrderId,
                        item = f.productName,
                        customerName = f.customerName,

                    })
                });


                    CustomerOrderBookings orderBookingStat = new CustomerOrderBookings();

                    foreach (var stat in bookingDetail)
                    {
            
                        foreach (var item in stat.statistics)
                        {
                            orderBookingStat.id = item.customerOrderId;
                            orderBookingStat.customer = item.customerName;
        
                            orderBookingStat.orderItems.Add(new BookedOrderItemDetail(){
                                id = item.customerOrderItemId,
                                productName = item.item,
                                neededAmount = item.needed,
                                bookedAmount = item.booked,
                                availableAmount = item.available,
                                afterBooking = item.available - (item.needed - item.booked),
                                remainingAmount =  item.needed - item.booked
                            });
                        }

                    }
            return orderBookingStat;
        }
    }

}


public class bookingStatistics {
     public float availableAmount {get; set;}
    public float inStock {get; set;}
    public float bookedAmount {get; set;}
    public float afterBooking {get; set;}
    public float needed {get; set;}
    public float remaining {get; set;}

    public bookingStatistics Accumilate(Item item) {
        inStock = item.ProductionOrderList.Sum(m => m.FinishedProduct.Where(f => f.Sales == null ).Count());
        bookedAmount = item.ProductionOrderList.Sum(m => m.FinishedProduct.Where(f => f.Sales == null && (m.PurchaseOrder != null ||  f.BookedStockItems != null) ).Count());
        return this;
    }

    public bookingStatistics Compute() {
        return this;
    }
}


/*var 

                    return boo; */