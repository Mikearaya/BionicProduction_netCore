/*
 * @CreateTime: Sep 26, 2018 8:50 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By: undefined
 * @Last Modified Time: Nov 1, 2018 12:08 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Interfaces;
using BionicInventory.Application.SalesOrders.Models;
using BionicInventory.Application.SalesOrders.Models.Booking;
using BionicInventory.Domain.PurchaseOrders;
using BionicInventory.Domain.PurchaseOrders.PurchaseOrderDetails;

namespace BionicInventory.Application.SalesOrders.Interfaces {
    public interface ISalesOrderQuery  {

        CustomerOrderDetailView GetCustomerOrderDetail(uint id);
        IEnumerable<CustomerOrdersView> GetAllCustomerOrders();
        PurchaseOrder GetSalesOrderById(uint id);
        PurchaseOrderDetail GetSalesOrderItemById(uint id);
        uint GetTotalBookedOrder(uint customerOrderItemId);
    }
}