using System;

namespace BionicInventory.Application.ProductionOrders.Models
{
    public class PendingOrdersView: WorkOrderView
    {
        public uint salesOrderId {get; set;}
        public uint productId {get; set;}
        public uint salesOrderItemId {get; set;} 
        public uint grantedQuantity {get; set;}
        public int itemCount {get; set;}
    }
}