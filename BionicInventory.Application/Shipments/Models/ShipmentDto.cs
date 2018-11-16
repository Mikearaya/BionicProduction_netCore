/*
 * @CreateTime: Nov 15, 2018 7:37 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 15, 2018 7:37 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.Shipments.Models
{
    public abstract class ShipmentDto
    {
        [Required]
        public DateTime deliveryDate {get; set;}
        public uint customerOrderId {get; set;}

        public uint bookedBy {get; set;}

        public string shipmentNote {get; set;}
        
    }
}