/*
 * @CreateTime: Nov 2, 2018 10:02 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 10:20 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Domain.BookedStockItem;
using BionicInventory.Domain.FinishedProducts;

namespace BionicInventory.Application.Products.Interfaces.Booking {
    public interface IStockBookingFactory {
        List<BookedStockItems> CreateBooking(IList<FinishedProduct> stockItems, uint customerOrderId, uint employeeId);
    }
}