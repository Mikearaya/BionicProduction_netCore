/*
 * @CreateTime: Nov 15, 2018 7:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 15, 2018 7:28 PM
 * @Description: Modify Here, Please 
 */
namespace BionicInventory.Application.Shipments.Models {
    public abstract class ShipmentItemDto {
        public uint CustomerOrderItemId { get; set; }
        public int Quantity { get; set; }
    }
}