using System.Collections.Generic;
using BionicInventory.Application.Interfaces;
using BionicInventory.Domain.PurchaseOrders;

namespace BionicInventory.Application.SalesOrders.Interfaces {
    public interface ISalesOrderCommand {

        IEnumerable<PurchaseOrder> CreateSalesOrder(IEnumerable<PurchaseOrder> orders);

        bool UpdateSalesOrder(IEnumerable<PurchaseOrder> orders);

        bool DeleteSalesOrders(PurchaseOrder order);

    }
}