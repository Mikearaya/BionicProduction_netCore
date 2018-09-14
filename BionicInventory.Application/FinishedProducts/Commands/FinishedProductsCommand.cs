/*
 * @CreateTime: Sep 1, 2018 10:14 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 15, 2018 12:14 AM
 * @Description: Modify Here, Please 
 */
using System;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.FinishedProducts.Interfaces;
using BionicInventory.Application.FinishedProducts.Models;
using BionicInventory.Domain.FinishedProducts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.FinishedProducts.Commands {
    public class FinishedProductsCommand : IFinishedProductsCommand {
        private readonly IInventoryDatabaseService _database;
        private readonly IFinishedProductsFactories _factory;
        private readonly ILogger<FinishedProductsCommand> _logger;

        public FinishedProductsCommand (IInventoryDatabaseService database,
            IFinishedProductsFactories factory,
            ILogger<FinishedProductsCommand> logger) {
            _database = database;
            _factory = factory;
            _logger = logger;
        }

        public FinishedProduct AddFinishedProduct (FinishedProduct finishedProduct) {

            try {

                _database.FinishedProduct.Add (finishedProduct);
                _database.Save ();

                return finishedProduct;

            } catch (Exception e) {
                _logger.LogError (null, e.Message, e);
                return null;
            }
        }

        public bool DeleteFinishedProduct (FinishedProduct finishedProduct) {

            try {

                _database.FinishedProduct.Remove (finishedProduct);
                _database.Save ();
                return true;

            } catch (Exception e) {

                _logger.LogError (null, e.Message, e);
                return false;
            }
        }

        public bool UpdateFinishedProduct (FinishedProduct finishedProduct) {

            try {

                _database.FinishedProduct.Update (finishedProduct);
                _database.Save ();
                return true;

            } catch (Exception e) {
                _logger.LogError (null, e.Message, e);
                return false;
            }
        }
    }
}