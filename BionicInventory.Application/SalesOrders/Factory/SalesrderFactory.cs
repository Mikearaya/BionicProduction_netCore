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
        public PurchaseOrder CreateNewSaleOrder(NewSalesOrderDto customerOrder )
        {
            PurchaseOrder newOrder = new PurchaseOrder() {
                ClientId = customerOrder.ClientId,
                CreatedBy = customerOrder.CreatedBy,
                InitialPayment = customerOrder.InitialPayment,
                PaymentMethod = customerOrder.PaymentMethod,
                Description = customerOrder.Description,
                Title = customerOrder.Title
            };
            foreach (var item in customerOrder.purchaseOrderDetail)
            {
            newOrder.PurchaseOrderDetail.Add(new PurchaseOrderDetail(){
                ItemId = item.ItemId,
                Quantity = item.Quantity,
                PricePerItem = item.UnitPrice,
                DueDate = item.DueDate
            });    
            }
            

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

        public uint ExtractId(string id) {
        string[] words = id.Split('-');
        bool isNumerical = uint.TryParse(words[1], out uint orderId);

            return (isNumerical) ? orderId : 0;

        }
    }
}