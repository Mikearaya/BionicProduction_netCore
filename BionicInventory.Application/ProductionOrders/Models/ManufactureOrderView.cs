namespace BionicInventory.Application.ProductionOrders.Models
{
    public class ManufactureOrderView: WorkOrderView
    {
        public uint id { get; set; }
        public uint orderId { get; set; }

        public string type { get; set; }

        public string status { get; set; }
        
    }
}