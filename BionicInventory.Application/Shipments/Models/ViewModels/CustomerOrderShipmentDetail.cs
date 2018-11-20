/*
 * @CreateTime: Nov 16, 2018 8:15 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 16, 2018 8:20 PM
 * @Description: Modify Here, Please 
 */
namespace BionicInventory.Application.Shipments.Models.ViewModels {
    public class CustomerOrderShipmentDetail {
        public uint customerOrderId { get; set; }
        public uint customerOrderItemId { get; set; }
        public uint itemId { get; set; }
        public string itemName { get; set; }

        public int? avalableForShipment { get; set; }
        public int? totalShiped { get; set; }
        public int? totalBooked { get; set; }
        public int? orderQuantity { get; set; }
    }
}