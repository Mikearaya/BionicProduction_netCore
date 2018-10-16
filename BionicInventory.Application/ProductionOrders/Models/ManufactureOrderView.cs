namespace BionicInventory.Application.ProductionOrders.Models
{
    public class ManufactureOrderView: WorkOrderView
    {
        //private string _manufacturerderItemId;
        //private string _manufacturerderId;
        public uint id{ get; set; }
        public uint orderId { get; set; }
        public string type { get; set; }

        public string status { get; set; }
        
    }
}