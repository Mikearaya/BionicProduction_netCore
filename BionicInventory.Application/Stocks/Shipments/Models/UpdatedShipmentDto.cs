/*
 * @CreateTime: Feb 15, 2019 8:41 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 15, 2019 8:49 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.Stocks.Shipments.Models {
    public class UpdatedShipmentDto {

        public uint Id { get; set; }
        public DateTime DeliveryDate { get; set; }

        [Required]
        public string status { get; set; }
        public IEnumerable<ShipmentDetailDto> ShipmentDetail { get; set; } = new List<ShipmentDetailDto> ();
    }
}