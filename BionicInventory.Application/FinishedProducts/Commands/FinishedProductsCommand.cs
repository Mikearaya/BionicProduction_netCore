/*
 * @CreateTime: Sep 1, 2018 10:14 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 21, 2018 11:24 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
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

        public List<FinishedProduct> AddFinishedProduct (List<FinishedProduct> finishedProducts) {

            try {
                List<FinishedProduct> newItemsList = new List<FinishedProduct> ();
                foreach (var item in finishedProducts) {
                    for (var i = 0; i < (int) item.Quantity; i++) {
                        FinishedProduct newItem = new FinishedProduct ();

                        newItem.Id = item.Id;
                        newItem.Quantity = item.Quantity;
                        newItem.OrderId = item.OrderId;
                        newItem.SubmittedBy = item.SubmittedBy;
                        newItem.RecievedBy = item.RecievedBy;

                        newItemsList.Add (newItem);
                        _database.FinishedProduct.AddRange (newItemsList);
                    }

                }
                _database.Save ();

            return newItemsList;
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