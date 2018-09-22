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

                return _database.FinishedProduct
                    .Select (fin => new FinishedProductsViewModel () {
                        id = fin.Id,

                            quantity = fin.Quantity,
                            recievedBy = fin.RecievedBy,
                            submittedBy = fin.SubmittedBy,
                            product = fin.Order.Item.Code,
                            orderId = fin.OrderId,
                            cost = fin.Order.CostPerItem,
                            dateAdded = (DateTime) fin.DateAdded,
                            submitter = fin.SubmittedByNavigation.FirstName + ' ' + fin.SubmittedByNavigation.LastName,
                            reciever = fin.RecievedByNavigation.FirstName + ' ' + fin.RecievedByNavigation.LastName,
                            dateUpdated = (DateTime) fin.DateUpdated
                    }).ToList ();
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