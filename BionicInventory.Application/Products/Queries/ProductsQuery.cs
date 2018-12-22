/*
 * @CreateTime: Sep 9, 2018 6:25 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 29, 2018 2:42 PM
 * @Description: Products Query Class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Products.Interfaces;
using BionicInventory.Application.Products.Models;
using BionicInventory.Domain.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Products.Queries {
    public class ProductsQuery : IProductsQuery {
        private readonly IInventoryDatabaseService _database;
        private readonly ILogger<ProductsQuery> _logger;

        public ProductsQuery (IInventoryDatabaseService database,
            ILogger<ProductsQuery> logger) {
            _database = database;
            _logger = logger;
        }
        public IEnumerable<Item> GetAllProduct () {

            try {

                return _database.Item.AsNoTracking ().ToList ();

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);
                return null;
            }
        }

        public bool IsProductCodeUnique (string code) {

            try {

                var result = _database.Item.Where (product => product.Code == code).FirstOrDefault ();
                return (result == null) ? true : false;

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);
                return false;
            }
        }

        public Item GetProductById (uint id) {

            try {
                return _database.Item.Find (id);
            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);
                return null;
            }
        }

        public ProductView GetProductViewById (uint id) {
            return _database.Item
                .Where (i => i.Id == id)
                .Select (ProductView.Projection)
                .FirstOrDefault ();
        }

        private IQueryable<CriticalStockItemsView> CriticalStockItemsGroup () {
            return _database.Item.GroupJoin (_database.ProductionOrderList, product => product.Id,
                manufOrder => manufOrder.ItemId,
                (product, manufactureOrder) => new CriticalStockItemsView () {

                    id = product.Id,

                        productCode = product.Code,

                        productName = product.Name,
                        minimumQuantity = product.MinimumQuantity,
                        inStock = manufactureOrder.Sum (MO => MO.FinishedProduct.Where (item => item.ShipmentDetail == null).Count ()),

                        availableQuantity = manufactureOrder.Sum (MO => MO.FinishedProduct
                            .Where (fin => fin.Order.PurchaseOrder == null && fin.ShipmentDetail == null && fin.OrderId == MO.Id).Count ()),
                        required = product.PurchaseOrderDetail.Where (CO => CO.ProductionOrderList == null).Sum (C => C.Quantity),
                        expectedAvailableQuantity = (int) manufactureOrder.Where (MO => MO.PurchaseOrder == null).Sum (MO => MO.Quantity -
                            MO.FinishedProduct.Count (fin => fin.ShipmentDetail == null || fin.Order.Id == MO.Id)),

                }).Where (item => item.minimumQuantity > ((item.availableQuantity + item.expectedAvailableQuantity) - item.required));
        }
        public IEnumerable<CriticalStockItemsView> GetCriticalBelowStockItems () {
            var criticalItems = CriticalStockItemsGroup ().GroupBy (item => item.id);

            List<CriticalStockItemsView> stockStatus = new List<CriticalStockItemsView> ();
            foreach (var item in criticalItems) {
                foreach (var status in item) {
                    if (status.required < status.minimumQuantity) {
                        status.required = (float) status.minimumQuantity - (status.availableQuantity + status.expectedAvailableQuantity);
                    } else {
                        status.required = status.required - (status.availableQuantity + status.expectedAvailableQuantity);
                    }
                    stockStatus.Add (status);
                }
            }
            return stockStatus;
        }

        public CriticalStockItemsView GetCriticalBelowStockItem (uint id) {
            var criticalItems = CriticalStockItemsGroup ()
                .Where (item => item.id == id).GroupBy (item => item.id).FirstOrDefault ();

            CriticalStockItemsView stockStatus = new CriticalStockItemsView ();
            foreach (var item in criticalItems) {
                if (item.required < item.minimumQuantity) {
                    item.required = (float) item.minimumQuantity - (item.availableQuantity + item.expectedAvailableQuantity);
                } else {
                    item.required = item.required - (item.availableQuantity + item.expectedAvailableQuantity);
                }

                stockStatus = item;
            }
            return stockStatus;
        }
    }
}