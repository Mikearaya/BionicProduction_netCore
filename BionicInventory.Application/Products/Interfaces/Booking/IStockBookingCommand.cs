/*
 * @CreateTime: Oct 31, 2018 9:26 PM
 * @Author: undefined
 * @Contact: undefined
 * @Last Modified By: undefined
 * @Last Modified Time: Oct 31, 2018 9:26 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Application.Products.Models.BookingModel;
using BionicInventory.Domain.BookedStockItem;
using BionicInventory.Domain.FinishedProducts;

namespace BionicInventory.Application.Products.Interfaces.Booking {

    public interface IStockBookingCommand {
        IEnumerable<BookedStockItems> BookAvailableStockItems (IEnumerable<BookedStockItems> bookedItems);

    }

}