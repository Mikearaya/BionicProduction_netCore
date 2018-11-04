/*
 * @CreateTime: Nov 1, 2018 8:35 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 3, 2018 10:06 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.SalesOrders.Models.Booking {

    public class OrderItemBookingDto {

        public sbyte? CreateManufactureOrder { get; set; }   
        [Required]
        public IEnumerable<BookingItemDto> Items {get; set;} 
        public uint BookedBy { get; set; }
        public DateTime? WorkStartDate { get; set; }
        public DateTime? WorkEndDate { get; set; }

    }

}