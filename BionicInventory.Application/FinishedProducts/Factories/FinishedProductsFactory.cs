/*
 * @CreateTime: Sep 14, 2018 11:15 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 2, 2018 8:36 PM
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
            current.SubmittedBy = updated.submitedBy;
            current.RecievedBy = updated.recievedBy;
            current.Quantity = updated.quantity;
            return current;
        }

        public FinishedProductsViewModel FinishedProductForView(FinishedProduct finishedProduct)
        {
            throw new NotImplementedException();
        }

        public List<FinishedProductsViewModel> FinishedProductForView(List<FinishedProduct> finishedProduct)
        {
            throw new NotImplementedException();
        }
    }
}