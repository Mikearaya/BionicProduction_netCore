/*
 * @CreateTime: Feb 15, 2019 8:44 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 15, 2019 10:31 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;

namespace BionicInventory.Application.Stocks.Shipments.Models {
    public class ShipmentDetailDto {
        public uint? Id { get; set; }
        public uint Quantity { get; set; }
        public uint LotBookingId { get; set; }
    }
}