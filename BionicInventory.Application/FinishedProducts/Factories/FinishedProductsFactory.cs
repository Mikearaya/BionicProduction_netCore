/*
 * @CreateTime: Sep 14, 2018 11:15 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 15, 2018 12:15 AM
 * @Description: Modify Here, Please 
 */

using System;
using BionicInventory.Application.Employees.Interfaces;
using BionicInventory.Application.FinishedProducts.Interfaces;
using BionicInventory.Application.FinishedProducts.Models;
using BionicInventory.Application.Products.Interfaces;
using BionicInventory.Domain.Employees;
using BionicInventory.Domain.FinishedProducts;
using BionicInventory.Domain.ProductionOrders.ProductionOrderLists;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.FinishedProducts.Factories {
    public class FinishedProductsFactory : IFinishedProductsFactories {
        private readonly ILogger<FinishedProductsFactory> _logger;
        private readonly IProductsQuery _productsQuery;
        private readonly IEmployeesQuery _employeeQuery;

        public FinishedProductsFactory (IEmployeesQuery employeesQuery,
            IProductsQuery productsQuery,
            ILogger<FinishedProductsFactory> logger) {
            _logger = logger;
            _productsQuery = productsQuery;
            _employeeQuery = employeesQuery;
        }
        public FinishedProduct NewFinishedProduct (ProductionOrderList order, Employee submited, Employee recieved, int quantity) {

            try {
                var finishedProduct = new FinishedProduct ();
                finishedProduct.OrderId = order.Id;
                finishedProduct.SubmittedBy = submited.Id;
                finishedProduct.RecievedBy = recieved.Id;
                finishedProduct.Quantity = quantity;

                return finishedProduct;

            } catch (Exception e) {
                _logger.LogError (null, e.Message, e);
                return null;
            }
        }

        public FinishedProduct FinishedProductForUpdate (FinishedProduct current, FinishedProductDTO updated) {

            try {

                current.OrderId = updated.orderId;
                current.SubmittedBy = updated.submittedBy;
                current.RecievedBy = updated.recievedBy;
                current.Quantity = updated.quantity;
                return current;

            } catch (Exception e) {
                _logger.LogError (null, e.Message, e);
                return null;
            }
        }

        public FinishedProductsViewModel FinishedProductForView (FinishedProduct finishedProduct) {

            try {
                var submittedBy = _employeeQuery.GetEmployeeById (finishedProduct.SubmittedBy);
                var recievedBy = _employeeQuery.GetEmployeeById (finishedProduct.RecievedBy);

                FinishedProductsViewModel view = new FinishedProductsViewModel () {
                    id = finishedProduct.Id,
                    orderId = finishedProduct.OrderId,
                    submittedBy = submittedBy.FullName (),
                    recievedBy = recievedBy.FullName (),
                    quantity = finishedProduct.Quantity,
                    dateAdded = (DateTime) finishedProduct.DateAdded,
                    dateUpdated = (DateTime) finishedProduct.DateUpdated

                };

                return view;

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);
                return null;
            }
        }

    }
}