/*
 * @CreateTime: Nov 15, 2018 7:30 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 15, 2018 7:33 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.Shipments.Models {
    public class NewShipmentDto : ShipmentDto {

        [Required]
        public List<NewShipmentItemDto> ShipmentItems { get; set; } = new List<NewShipmentItemDto> ();

    }
}