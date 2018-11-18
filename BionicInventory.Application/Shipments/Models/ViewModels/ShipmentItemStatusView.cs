/*
 * @CreateTime: Nov 15, 2018 8:07 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 18, 2018 8:11 PM
 * @Description: Modify Here, Please 
 */
namespace BionicInventory.Application.Shipments.Models.ViewModels {
    public class ShipmentItemStatusView {
        public uint customerOrderItemId { get; set; }
        public string itemName { get; set; }
        public int shippedQuantity { get; set; }
        public int bookedQuantity { get; set; }
        public int? Quantity { get; set; }
        public int? pickedQuantity { get; set; }
        public int remainingShipments { get; set; }
        public int availableItems { get; set; }
        public string status { get; set; }
    }
}