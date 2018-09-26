/*
 * @CreateTime: Sep 26, 2018 8:55 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 26, 2018 9:27 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.SalesOrders.Interfaces;
using BionicInventory.Application.SalesOrders.Models;
using BionicInventory.Domain.PurchaseOrders;
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
        public IEnumerable<SalesOrderView> GetAllSalesOrders () {

            return _database.PurchaseOrderDetail.Select (sales => new SalesOrderView () {
                Id = sales.PurchaseOrderId,
                    CustomerName = sales.PurchaseOrder.Client.FirstName + " " + sales.PurchaseOrder.Client.LastName,
                    OrderCode = $"{sales.PurchaseOrder.Id}-{sales.Id}",
                    CreatedBy = $"{sales.PurchaseOrder.CreatedByNavigation.FullName()}",
                    Quantity = sales.Quantity,
                    ItemCode = sales.Item.Code,
                    UnitPrice = (float) sales.PricePerItem,
                    paidAmount = (float) sales.PurchaseOrder.InitialPayment,
                    remainingPayment = ((double)sales.PricePerItem * sales.Quantity) - sales.PurchaseOrder.InitialPayment,
                    totalAmount = (double)sales.PricePerItem * sales.Quantity,
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