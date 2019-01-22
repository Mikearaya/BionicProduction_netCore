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
using BionicInventory.Application.Inventory.StockBatchs.Models;
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

            return _database.Item.Include (u => u.PrimaryUom).GroupJoin (_database.StockBatchStorage, product => product.Id,
                    manufOrder => manufOrder.Batch.ItemId,
                    (product, manufactureOrder) => new {

                        item = product,

                            lot = manufactureOrder.DefaultIfEmpty (),

                    }).GroupBy (manuf => manuf.item)
                .Select (i => new StockStatusView () {
                    itemName = i.Key.Name,
                        itemCode = i.Key.Code,
                        primaryUom = i.Key.PrimaryUom.Abrivation,
                        itemId = i.Key.Id,
                        primaryUomId = i.Key.PrimaryUomId,
                        minimumQuantity = i.Key.MinimumQuantity,
                        inStock = i.Sum (f => f.lot.Where (l => l.Batch.Status.ToUpper () == "RECIEVED").Sum (q => q.Quantity)),
                        totalWriteOff = i.Sum (l => l.lot.Sum (w => w.WriteOffDetail.Sum (q => q.Quantity))),
                        booked = i.Sum (l => l.lot.Where (c => c.Batch.Status.ToUpper () == "RECIEVED").Sum (b => b.BookedStockBatch.Sum (q => q.Quantity))),
                        expectedBooked = i.Sum (l => l.lot.Where (c => c.Batch.Status.ToUpper () != "RECIEVED").Sum (b => b.BookedStockBatch.Sum (q => q.Quantity))),
                        totalExpected = i.Sum (l => l.lot.Where (c => c.Batch.Status.ToUpper () != "RECIEVED").Sum (b => b.Quantity)),

                        totalCost = i.Sum (m => m.lot.Sum (r => r.Batch.UnitCost * r.Quantity))

                }).ToList ();

        }
    }
}