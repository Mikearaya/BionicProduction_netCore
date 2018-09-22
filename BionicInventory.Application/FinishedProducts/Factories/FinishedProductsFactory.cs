/*
 * @CreateTime: Sep 14, 2018 11:15 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 21, 2018 11:09 PM
 * @Description: Modify Here, Please 
 */

using System;
using System.Collections.Generic;
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
            var finishedProduct = new FinishedProduct ();
            finishedProduct.OrderId = order.Id;
            finishedProduct.SubmittedBy = submited.Id;
            finishedProduct.RecievedBy = recieved.Id;
            finishedProduct.Quantity = quantity;

            return finishedProduct;
        }

        public FinishedProduct FinishedProductForUpdate (UpdatedFinishedProductDto updated) {
            FinishedProduct current = new FinishedProduct ();
            current.OrderId = updated.orderId;
            current.SubmittedBy = updated.submittedBy;
            current.RecievedBy = updated.recievedBy;
            current.Quantity = updated.quantity;
            return current;
        }

        public FinishedProductsViewModel FinishedProductForView (FinishedProduct finishedProduct) {

            var submittedBy = _employeeQuery.GetEmployeeById (finishedProduct.SubmittedBy);
            var recievedBy = _employeeQuery.GetEmployeeById (finishedProduct.RecievedBy);

            FinishedProductsViewModel view = new FinishedProductsViewModel () {
                id = finishedProduct.Id,
                orderId = finishedProduct.OrderId,
                submitter = submittedBy.FullName (),
                reciever = recievedBy.FullName (),
                submittedBy = submittedBy.Id,
                recievedBy = recievedBy.Id,
                quantity = finishedProduct.Quantity,
                dateAdded = (DateTime) finishedProduct.DateAdded,
                dateUpdated = (DateTime) finishedProduct.DateUpdated

            };

            return view;

        }

        public List<FinishedProductsViewModel> FinishedProductForView (List<FinishedProduct> finishedProducts) {

            List<FinishedProductsViewModel> finishedProductsList = new List<FinishedProductsViewModel> ();

            foreach (var item in finishedProducts) {

                var submittedBy = _employeeQuery.GetEmployeeById (item.SubmittedBy);
                var recievedBy = _employeeQuery.GetEmployeeById (item.RecievedBy);

                FinishedProductsViewModel view = new FinishedProductsViewModel () {
                    id = item.Id,
                    orderId = item.OrderId,
                    submitter = submittedBy.FullName (),
                    reciever = recievedBy.FullName (),
                    submittedBy = submittedBy.Id,
                    recievedBy = recievedBy.Id,
                    quantity = item.Quantity,
                
                    dateAdded = (DateTime) item.DateAdded,
                    dateUpdated = (DateTime) item.DateUpdated

                };
                finishedProductsList.Add (view);

            }
            return finishedProductsList;
        }
    }
}