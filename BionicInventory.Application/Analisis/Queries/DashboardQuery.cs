/*
 * @CreateTime: Nov 21, 2018 11:14 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 21, 2018 11:19 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Analisis.Interfaces;
using BionicInventory.Application.Analisis.Models;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Analisis.Queries {
    public class DashboardQuery : IDashboardQuery {
        private readonly ILogger<DashboardQuery> _logger;
        private readonly IInventoryDatabaseService _database;

        public DashboardQuery (IInventoryDatabaseService database,
            ILogger<DashboardQuery> logger) {
            _logger = logger;
            _database = database;
        }
        public SummaryDataModel GetCurrentActivityStats () {

            return new SummaryDataModel () {
                totalInventoryCost = GetTotalStockCost (),
                    activeManufactureOrders = GetActiveManufactureOrders (),
                    totalCustomers = GetTotalCustomer (),
                    totalProducts = GetTotalProducts (),
                    overDueMO = GetLateManufactureOrdersCount (),
                    overDuePayments = GetSevenDaysDueInvoiceCount (),
                    totalMinStock = GetStockItemBelowMinimumQuantityCount (),
                    totalMonthlySale = GetCurrentMonthTotalSales ()
            };

        }

        private int GetActiveManufactureOrders () {
            return _database.Item.Sum (i => i.ProductionOrderList
                .Count (f => f.FinishedProduct
                    .Count () != f.Quantity &&
                    f.DueDate.Month == DateTime.Today.Month));

        }

        private int GetTotalCustomer () {
            return _database.Customer.Count ();
        }

        private int GetTotalProducts () {
            return _database.Item.Count ();
        }

        private int GetCurrentMonthTotalSales () {
            return _database.Invoice.Where (i => i.DateAdded.Value.Month == DateTime.Today.Month).Count ();
        }

        private double? GetTotalStockCost () {
            return (from pro in _database.Item join mo in _database.ProductionOrderList on pro.Id equals mo.ItemId join fin in _database.FinishedProduct on mo.Id equals fin.OrderId where fin.BookedStockItems == null && fin.ShipmentDetail == null && mo.CustomerOrderItem == null select new {
                cost = (double?) mo.Quantity * mo.CostPerItem
            }).Sum (c => c.cost);
        }

        private int GetSevenDaysDueInvoiceCount () {
            return _database.Invoice.Where (i => (DateTime.Today - i.DueDate.Value).TotalDays > 6)
                .Count (i => i.InvoiceDetail
                    .Sum (id => (double?) id.Quantity * id.UnitPrice) >
                    i.InvoicePayments.Sum (p => p.Amount));
        }

        private int GetLateManufactureOrdersCount () {
            return (from mo in _database.ProductionOrderList join fin in _database.FinishedProduct on mo.Id equals fin.OrderId where ((DateTime.Today - mo.DueDate).TotalDays > 0 &&
                    fin.ShipmentDetail == null) ||
                mo.FinishedProduct == null select new {
                    moId = mo.Id
                }
            ).GroupBy (m => m.moId).Count ();
        }

        private int GetStockItemBelowMinimumQuantityCount () {
            return _database.Item.GroupJoin (_database.ProductionOrderList, product => product.Id,
                    manufOrder => manufOrder.ItemId,
                    (product, manufactureOrder) => new {
                        id = product.Id,
                            minimumQuantity = product.MinimumQuantity,
                            inStock = manufactureOrder.Sum (MO => MO.FinishedProduct.Where (item => item.ShipmentDetail == null).Count ()),

                            availableQuantity = manufactureOrder.Sum (MO => MO.FinishedProduct
                                .Where (fin => fin.Order.CustomerOrderItem == null && fin.ShipmentDetail == null && fin.OrderId == MO.Id).Count ()),
                            required = product.CustomerOrderItem.Where (CO => CO.ProductionOrderList == null).Sum (C => C.Quantity),
                            expectedAvailableQuantity = (int) manufactureOrder.Where (MO => MO.CustomerOrderItem == null).Sum (MO => MO.Quantity -
                                MO.FinishedProduct.Count (fin => fin.ShipmentDetail == null || fin.Order.Id == MO.Id)),

                    }).Where (item => item.minimumQuantity > ((item.availableQuantity + item.expectedAvailableQuantity) - item.required))
                .GroupBy (g => g.id)
                .Count ();
        }
    }
}