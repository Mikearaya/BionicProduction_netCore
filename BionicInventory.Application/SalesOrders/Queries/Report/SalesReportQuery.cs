/*
 * @CreateTime: Nov 21, 2018 9:21 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 21, 2018 9:36 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.SalesOrders.Interfaces;
using BionicInventory.Application.SalesOrders.Models.ReportModels;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.SalesOrders.Queries.Report {
    public class SalesOrderReportQuery : ISalesOrderReportQuery {
        private readonly IInventoryDatabaseService _database;
        private readonly ILogger<SalesOrderReportQuery> _logger;

        public SalesOrderReportQuery (IInventoryDatabaseService database,
            ILogger<SalesOrderReportQuery> logger) {
            _database = database;
            _logger = logger;
        }

        private IQueryable<MonthlySalesReportModel> IQueryableMonthlySalesReport () {
            return _database.PurchaseOrder
                .Where (co => co.DateAdded.Value.Year == DateTime.Today.Year)
                .GroupBy (co => co.DateAdded.Value.Month)
                .Select (d => new MonthlySalesReportModel () {

                    month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName (d.Key),
                        amount = d.Sum (prof => (double?) prof.PurchaseOrderDetail
                            .Sum (er => (double?) er.PricePerItem * (double?) er.Quantity) - (double?) prof.PurchaseOrderDetail
                            .Sum (wo => (double?) wo.ProductionOrderList.CostPerItem * (double?) wo.ProductionOrderList.Quantity)),
                });
        }

        public MonthlySalesReportModel GetSalesReportForAMonth (int monthNumber) {
            return IQueryableMonthlySalesReport ()
                .Where (m => m.month == CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName (monthNumber))
                .FirstOrDefault ();
        }

        public IEnumerable<MonthlySalesReportModel> GetYearlySalesReport () {
            return IQueryableMonthlySalesReport ().ToList ();
        }
    }
}