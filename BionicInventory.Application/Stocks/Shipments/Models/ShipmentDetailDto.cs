/*
 * @CreateTime: Feb 15, 2019 8:44 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 15, 2019 8:59 PM
 * @Description: Modify Here, Please 
 */
namespace BionicInventory.Application.Stocks.Shipments.Models {
    public class ShipmentDetailDto {
        public uint? Id { get; set; }
        public uint Quantity { get; set; }
        public uint LotBookingId { get; set; }
    }
}