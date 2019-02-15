/*
 * @CreateTime: Feb 15, 2019 8:41 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 15, 2019 8:48 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.Stocks.Shipments.Models {
    public class NewShipmentDto : IRequest<uint> {
        public DateTime DeliveryDate { get; set; }

        [Required]
        public string Status { get; set; }
        public IEnumerable<ShipmentDetailDto> ShipmentDetail { get; set; } = new List<ShipmentDetailDto> ();
    }
}