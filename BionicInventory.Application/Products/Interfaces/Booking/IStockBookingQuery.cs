/*
 * @CreateTime: Oct 24, 2018 11:00 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 24, 2018 11:02 PM
 * @Description: Modify Here, Please 
 */
using System;
using BionicInventory.Application.Products.Models.BookingModel;

namespace BionicInventory.Application.Products.Interfaces.Booking {
    public interface IStockBookingQuery {
        CustomerOrderBookings GetCustomerOrderBookings(uint id);
        
    }

}