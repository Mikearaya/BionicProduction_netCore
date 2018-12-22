/*
 * @CreateTime: Sep 14, 2018 10:49 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 14, 2018 11:32 PM
 * @Description: FinishedProducts database Query Class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.FinishedProducts.Interfaces;
using BionicInventory.Application.FinishedProducts.Models;
using BionicInventory.Domain.FinishedProducts;
using BionicInventory.Domain.ProductionOrders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.FinishedProducts.Queries {
    public class FinishedProductsQuery : IFinishedProductsQuery {
        private readonly IInventoryDatabaseService _database;
        private readonly ILogger<FinishedProductsQuery> _logger;

        public FinishedProductsQuery (IInventoryDatabaseService database,
            ILogger<FinishedProductsQuery> logger
        ) {
            _database = database;
            _logger = logger;

        }
        public List<FinishedProductsViewModel> GetAllFinishedProducts () {

            try {

                var result = _database.FinishedProduct
                    .GroupBy (prod => prod.Order.ItemId)
                    .Select (finished => new {

                        quantity = finished.Count (),
                            cost = finished.Sum (su => su.Order.CostPerItem),
                            FinishedProduct = finished.Where (r => r.Order.ItemId == finished.Key).Select (detail => new {
                                product = detail.Order.Item.Code,
                                    cost = detail.Order.CostPerItem,
                            }).FirstOrDefault ()
                    }).ToList ();

                List<FinishedProductsViewModel> view = new List<FinishedProductsViewModel> ();
                foreach (var item in result) {

                    view.Add (new FinishedProductsViewModel () {
                        quantity = item.quantity,
                            product = item.FinishedProduct.product,
                            cost = item.cost
                    });

                }

                return view;
            } catch (Exception e) {

                _logger.LogError (100, e.Message, e);
                return null;
            }
        }

        public FinishedProduct GetFinishedProductById (uint id) {

            try {

                var product = _database.FinishedProduct.FirstOrDefault (prod => prod.Id == id);
                _logger.LogInformation (1, "Product successfully fetched ", product);

                return product;

            } catch (Exception e) {

                _logger.LogError (100, e.Message, e);
                return null;
            }

        }

        public IEnumerable<FinishedProduct> GetFinishedProductByOrder (uint orderId) {

            try {

                return _database.FinishedProduct.Where (prod => prod.Order.Id == orderId).AsNoTracking ().ToList ();

            } catch (Exception e) {

                _logger.LogError (100, e.Message, e);
                return null;
            }

        }

        public IEnumerable<StockStatusView> GetStockReport () {

            var stock = _database.Item.GroupJoin (_database.ProductionOrderList, product => product.Id,
                manufOrder => manufOrder.ItemId,
                (product, manufactureOrder) => new StockStatusView () {

                    itemId = product.Id,

                        itemCode = product.Code,

                        itemName = product.Name,

                        primaryUomId = product.PrimaryUomId,
                        minimumQuantity = product.MinimumQuantity,

                        averageCost = manufactureOrder.Sum (item => item.CostPerItem) / manufactureOrder.Count (),

                        inStock = manufactureOrder.Sum (MO => MO.FinishedProduct.Where (item => item.ShipmentDetail == null).Count ()),

                        totalCost = manufactureOrder.Sum (MO => MO.CostPerItem * (MO.Quantity - (MO.FinishedProduct.Count (fin => fin.ShipmentDetail != null)))),

                        booked = manufactureOrder.Sum (MO => MO.FinishedProduct
                            .Where (fin => (fin.Order.PurchaseOrder != null || fin.BookedStockItems != null) && fin.ShipmentDetail == null && fin.OrderId == MO.Id).Count ()),

                        available = manufactureOrder.Sum (MO => MO.FinishedProduct
                            .Where (fin => fin.Order.PurchaseOrder == null && fin.ShipmentDetail == null && fin.BookedStockItems == null && fin.OrderId == MO.Id).Count ()),

                        expectedAvailable = (int) manufactureOrder.Where (MO => MO.PurchaseOrder == null).Sum (MO => MO.Quantity -
                            MO.FinishedProduct.Count (fin => fin.ShipmentDetail == null)),

                        expectedBooked = (int) manufactureOrder.Where (MO => MO.PurchaseOrder != null).Sum (MO => MO.Quantity - MO.FinishedProduct
                            .Count (fin => fin.ShipmentDetail == null)),

                        totalExpected = (int) manufactureOrder.Sum (MO => MO.Quantity - MO.FinishedProduct.Count (fin => (fin.ShipmentDetail == null && fin.BookedStockItems == null) || fin.Order != null))
                }).GroupBy (manuf => manuf.itemId).ToList ();

            List<StockStatusView> stockStatus = new List<StockStatusView> ();
            foreach (var item in stock) {
                foreach (var status in item) {
                    stockStatus.Add (status);

                }
            }
            return stockStatus;

        }
    }
}