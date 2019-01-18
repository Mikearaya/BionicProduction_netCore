using System;
using System.Collections.Generic;
using BionicInventory.Application.SalesOrders.Interfaces;
using BionicInventory.Application.SalesOrders.Models;
using BionicInventory.Domain.CustomerOrders;
using BionicInventory.Domain.Customers;
using BionicInventory.Domain.Employees;
using BionicInventory.Domain.Items;

namespace BionicInventory.Application.SalesOrders.Factory {
    public class SalesOrderFactory : ISalesOrderFactory {

        public CustomerOrder CreateNewSaleOrder (NewSalesOrderDto customerOrder) {
            CustomerOrder newOrder = new CustomerOrder () {
                ClientId = customerOrder.ClientId,
                CreatedBy = customerOrder.CreatedBy,
                OrderStatus = customerOrder.Status,
                Description = customerOrder.Description,
                DueDate = customerOrder.DeliveryDate,
            };
            foreach (var item in customerOrder.purchaseOrderDetail) {
                newOrder.CustomerOrderItem.Add (new CustomerOrderItem () {
                    ItemId = item.ItemId,
                        Quantity = item.Quantity,
                        PricePerItem = item.UnitPrice,
                        DueDate = item.DueDate
                });
            }

            return newOrder;
        }

        public SalesOrderView CreateSaleOrderView (CustomerOrder newOrder) {
            throw new NotImplementedException ();
        }

        public IEnumerable<CustomerOrder> CreateUpdatesSaleOrder (IEnumerable<UpdatedSalesOrderDto> newOrder) {
            throw new NotImplementedException ();
        }

        public uint ExtractId (string id) {
            string[] words = id.Split ('-');
            bool isNumerical = uint.TryParse (words[1], out uint orderId);

            return (isNumerical) ? orderId : 0;

        }
    }
}