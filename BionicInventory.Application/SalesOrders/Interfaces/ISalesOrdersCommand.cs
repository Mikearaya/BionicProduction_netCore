using System.Collections.Generic;
using BionicInventory.Application.Interfaces;
using BionicInventory.Domain.PurchaseOrders;

namespace BionicInventory.Application.SalesOrders.Interfaces {
    public interface ISalesOrdersCommand {

        IEnumerable<PurchaseOrder> CreateSalesOrder(IEnumerable<PurchaseOrder> orders);

        bool UpdateSalesOrder(IEnumerable<PurchaseOrder> orders);

        bool DeleteSalesOrders(PurchaseOrder order);

    }
}