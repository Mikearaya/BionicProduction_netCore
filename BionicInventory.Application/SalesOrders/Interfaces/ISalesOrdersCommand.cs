using BionicInventory.Application.Interfaces;
using BionicInventory.Domain.PurchaseOrders;

namespace BionicInventory.Application.SalesOrders.Interfaces {
    public interface ISalesOrdersCommand : IBasicCommand<PurchaseOrder> {

    }
}