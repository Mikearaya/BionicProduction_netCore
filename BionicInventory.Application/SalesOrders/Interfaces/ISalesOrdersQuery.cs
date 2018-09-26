using System.Collections.Generic;
using BionicInventory.Application.Interfaces;
using BionicInventory.Application.SalesOrders.Models;
using BionicInventory.Domain.PurchaseOrders;

namespace BionicInventory.Application.SalesOrders.Interfaces {
    public interface ISalesOrdersQuery  {

        IEnumerable<SalesOrderView> GetAllSalesOrders();
        PurchaseOrder GetSalesOrderById(uint id);
    }
}