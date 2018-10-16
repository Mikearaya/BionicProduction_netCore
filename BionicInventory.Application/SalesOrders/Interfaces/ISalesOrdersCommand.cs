using System.Collections.Generic;
using BionicInventory.Application.Interfaces;
using BionicInventory.Domain.PurchaseOrders;

namespace BionicInventory.Application.SalesOrders.Interfaces {
    public interface ISalesOrderCommand {

        PurchaseOrder CreateSalesOrder(PurchaseOrder orders);

        bool UpdateSalesOrder(IEnumerable<PurchaseOrder> orders);

        bool DeleteSalesOrders(PurchaseOrder order);

    }
}