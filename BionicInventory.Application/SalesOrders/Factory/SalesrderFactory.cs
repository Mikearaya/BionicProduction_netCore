using System;
using System.Collections.Generic;
using BionicInventory.Application.SalesOrders.Interfaces;
using BionicInventory.Application.SalesOrders.Models;
using BionicInventory.Domain.Customers;
using BionicInventory.Domain.Employees;
using BionicInventory.Domain.Items;
using BionicInventory.Domain.PurchaseOrders;
using BionicInventory.Domain.PurchaseOrders.PurchaseOrderDetails;

namespace BionicInventory.Application.SalesOrders.Factory
{
    public class SalesOrderFactory : ISalesOrderFactory
    {
        public PurchaseOrder CreateNewSaleOrder(Customer customers, Employee createdBy, Item item, uint quantity, DateTime dueDate, float unitPrice, float downPayment, string description, string method = "CASH" )
        {
            PurchaseOrder newOrder = new PurchaseOrder() {
                ClientId = customers.Id,
                CreatedBy = createdBy.Id,
                InitialPayment = downPayment,
                PaymentMethod = method
            };
            newOrder.PurchaseOrderDetail.Add(new PurchaseOrderDetail(){
                ItemId = item.Id,
                Quantity = quantity,
                PricePerItem = unitPrice,
                DueDate = dueDate
            });

            return newOrder;
        }

        public SalesOrderView CreateSaleOrderView(PurchaseOrder newOrder)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PurchaseOrder> CreateUpdatesSaleOrder(IEnumerable<UpdatedSalesOrderDto> newOrder)
        {
            throw new NotImplementedException();
        }
    }
}