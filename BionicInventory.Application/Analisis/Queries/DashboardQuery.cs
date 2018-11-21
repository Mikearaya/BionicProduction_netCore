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
        public void GetCurrentActivityStats () {

            var x = _database.Item.Sum (i => i.ProductionOrderList.Count (f => f.FinishedProduct.Count () != f.Quantity &&
                f.DueDate.Month == DateTime.Today.Month));
            Console.Write (x);

            var w = _database.PurchaseOrder
                .Where (co => co.DateAdded.Value.Month == DateTime.Today.Month)
                .GroupBy (co => co.DateAdded.Value.Month == DateTime.Today.Month)
                .Select (d => new {
                    total = d.Count (),
                        profit = d.Sum (prof => (double?) prof.PurchaseOrderDetail
                            .Sum (er => (double?) er.PricePerItem * (double?) er.Quantity) - (double?) prof.PurchaseOrderDetail
                            .Sum (wo => (double?) wo.ProductionOrderList.CostPerItem * (double?) wo.ProductionOrderList.Quantity)),
                });

            var y = _database.PurchaseOrder
                .Where (co => co.DateAdded.Value.Year == DateTime.Today.Year)
                .GroupBy (co => co.DateAdded.Value.Month)
                .Select (d => new {
                    total = d.Count (),
                        month = d.Key,
                        profit = d.Sum (prof => (double?) prof.PurchaseOrderDetail
                            .Sum (er => (double?) er.PricePerItem * (double?) er.Quantity) - (double?) prof.PurchaseOrderDetail
                            .Sum (wo => (double?) wo.ProductionOrderList.CostPerItem * (double?) wo.ProductionOrderList.Quantity)),
                });

            foreach (var item in w) {
                Console.Write ($"total {item.total}\n");
                Console.Write ($"profit {item.profit}\n");

            }

            foreach (var item in y) {

                var c = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName (item.month);
                Console.Write ($"month = {c} --- profit {item.profit}\n");
            }
        }
    }
}