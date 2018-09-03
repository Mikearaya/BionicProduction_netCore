/*
 * @CreateTime: Sep 1, 2018 10:14 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 1, 2018 10:17 PM
 * @Description: Modify Here, Please 
 */
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.FinishedProducts.Interfaces;
using BionicInventory.Application.FinishedProducts.Models;
using BionicInventory.Domain.FinishedProducts;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.FinishedProducts.Commands {
    public class FinishedProductsCommand : IFinishedProductsCommand {
        private readonly IInventoryDatabaseService _database;
        private readonly IFinishedProductsFactories _factory;

        public FinishedProductsCommand (IInventoryDatabaseService database,
            IFinishedProductsFactories factory) {
                _database = database;
                _factory = factory;
        }

        public FinishedProductsViewModel AddFinishedProduct (FinishedProduct finishedProduct) {

                _database.FinishedProduct.Add(finishedProduct);
                _database.Save();
                return _factory.FinishedProductForView(finishedProduct);
        }

        public bool DeleteFinishedProduct (FinishedProduct finishedProduct) {
                _database.FinishedProduct.Remove(finishedProduct);
                _database.Save();
                return true;
        }

        public bool UpdateFinishedProduct (FinishedProduct finishedProduct) {
            _database.FinishedProduct.Add(finishedProduct).State = EntityState.Modified;
            _database.Save();
            return true;
        }
    }
}