/*
 * @CreateTime: Nov 15, 2018 8:07 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 15, 2018 8:07 PM
 * @Description: Modify Here, Please 
 */
namespace BionicInventory.Application.Shipments.Models.ViewModels {
    public class ShipmentItemStatusView {
        public uint id { get; set; }
        public uint customerOrderItemId { get; set; }
        public string itemName { get; set; }
        public int shippedQuantity { get; set; }
        public int remainingShipments { get; set; }
        public int availableItems { get; set; }
        public string status { get; set; }
    }
}