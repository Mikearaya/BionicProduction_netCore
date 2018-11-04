/*
 * @CreateTime: Oct 24, 2018 11:00 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 9:36 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Application.Products.Models.BookingModel;
using BionicInventory.Domain.FinishedProducts;

namespace BionicInventory.Application.Products.Interfaces.Booking {
    public interface IStockBookingQuery {
        CustomerOrderBookings GetCustomerOrderBookings(uint id);
        IList<FinishedProduct> GetAvailableCustomerOrderItem(uint customerOrderId);
        IList<FinishedProduct> AvailableStockItemsForOrder(int quantity, uint customerOrderId);
        
    }

}