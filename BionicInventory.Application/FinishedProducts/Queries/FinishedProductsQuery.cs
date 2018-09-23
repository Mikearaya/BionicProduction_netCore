/*
 * @CreateTime: Sep 14, 2018 10:49 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 21, 2018 10:43 PM
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
                                //   orderId = detail.OrderId,
                                //     Id = detail.Id,
                                //         submittedBy = detail.SubmittedBy,
                                //       recievedBy = detail.RecievedBy,
                                product = detail.Order.Item.Code,
                                    cost = detail.Order.CostPerItem,
                                    //   DateAdded = detail.DateAdded,
                                    // DateUpdated = detail.DateUpdated,

                                    // submitter = detail.RecievedByNavigation.FirstName + ' ' + detail.RecievedByNavigation.LastName,
                                    // reciever = detail.RecievedByNavigation.FirstName + ' ' + detail.RecievedByNavigation.LastName
                            }).FirstOrDefault ()
                    }).ToList ();

                List<FinishedProductsViewModel> view = new List<FinishedProductsViewModel> ();
                foreach (var item in result) {

                    view.Add (new FinishedProductsViewModel () {
                        //   id = item.FinishedProduct.Id,
                        quantity = item.quantity,
                            //        submittedBy = item.FinishedProduct.submittedBy,
                            //      recievedBy = item.FinishedProduct.recievedBy,
                            product = item.FinishedProduct.product,
                            cost = item.cost,
                            //       orderId = item.FinishedProduct.orderId,
                            //      submitter = item.FinishedProduct.submitter,
                            //    reciever = item.FinishedProduct.reciever,

                            //                            dateAdded = (DateTime) item.FinishedProduct.DateAdded,
                            //                          dateUpdated = (DateTime) item.FinishedProduct.DateUpdated
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
    }
}