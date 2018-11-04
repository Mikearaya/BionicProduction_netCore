/*
 * @CreateTime: Oct 31, 2018 9:26 PM
 * @Author: undefined
 * @Contact: undefined
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 10:11 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Application.Products.Models.BookingModel;
using BionicInventory.Domain.BookedStockItem;
using BionicInventory.Domain.FinishedProducts;

namespace BionicInventory.Application.Products.Interfaces.Booking {

    public interface IStockBookingCommand {
        IList<BookedStockItems> BookAvailableStockItems (IList<BookedStockItems> bookedItems);
        
    }

}