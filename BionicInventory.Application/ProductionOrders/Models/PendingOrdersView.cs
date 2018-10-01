namespace BionicInventory.Application.ProductionOrders.Models
{
    public class PendingOrdersView: WorkOrderView
    {
        public uint purchaseOrderId {get; set;}
        public uint purchaseOrderItemId {get; set;} 
    }
}