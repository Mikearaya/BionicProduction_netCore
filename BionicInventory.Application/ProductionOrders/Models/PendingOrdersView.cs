using System;

namespace BionicInventory.Application.ProductionOrders.Models
{
    public class PendingOrdersView: WorkOrderView
    {
   //     private string _salesOrderId;
        //private string _salesOrderItemId;

        //private string _productId;
        public uint salesOrderId { get; set; }
        public uint grantedQuantity {get; set;}
        public int itemCount {get; set;}
    }
}