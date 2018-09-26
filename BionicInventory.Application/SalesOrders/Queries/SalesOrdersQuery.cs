using System;
using System.Collections.Generic;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.SalesOrders.Interfaces;
using BionicInventory.Application.SalesOrders.Models;
using BionicInventory.Domain.PurchaseOrders;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.SalesOrders.Queries {
    public class SalesOrdersQuery : ISalesOrdersQuery {
        private readonly IInventoryDatabaseService _database;
        private readonly ILogger<SalesOrdersQuery> _logger;

        public SalesOrdersQuery (IInventoryDatabaseService databse,
            ILogger<SalesOrdersQuery> logger) {
            _database = databse;
            _logger = logger;
        }
        public IEnumerable<SalesOrderView> GetAllSalesOrders () {

            return _database.PurchaseOrderDetail.Select (sales => new SalesOrderView () {
                Id = sales.PurchaseOrderId,
                    CustomerName = sales.PurchaseOrder.Client.FirstName + " " + sales.PurchaseOrder.Client.LastName,
                    OrderCode = $"{sales.PurchaseOrder.Id}-{sales.Id}",
                    CreatedBy = $"{sales.PurchaseOrder.CreatedByNavigation.FullName()}",
                    Quantity = sales.Quantity,
                    ItemCode = sales.Item.Code,
                    UnitPrice = sales.PricePerItem,
                    totalAmount = sales.PricePerItem * sales.Quantity,
                    OrderedOn = (DateTime) sales.DateAdded,
                    DueDate = sales.DueDate

            }).ToList ();

        }

        public PurchaseOrder GetSalesOrderById (uint id) {
            return _database.PurchaseOrder.Where(order => order.Id == id).Select (sales => new PurchaseOrder () {
                Id = sales.Id,
                ClientId = sales.ClientId,
                InitialPayment = sales.InitialPayment,
                CreatedBy = sales.CreatedBy,
                PaymentMethod = sales.PaymentMethod,
                PurchaseOrderDetail = sales.PurchaseOrderDetail.Where(detail => detail.PurchaseOrderId == id ).ToList()
            }).FirstOrDefault();
        }
    }
}