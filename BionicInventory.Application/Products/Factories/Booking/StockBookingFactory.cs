

using System.Collections.Generic;
using BionicInventory.Application.Products.Interfaces.Booking;
using BionicInventory.Domain.BookedStockItem;
using BionicInventory.Domain.FinishedProducts;

namespace BionicInventory.Application.Products.Factories.Booking {
    public class StockBookingFactory : IStockBookingFactory
    {
        public List<BookedStockItems> CreateBooking(IList<FinishedProduct> stockItems, uint customerOrderId,  uint employeeId)
        {
            List<BookedStockItems> booking = new List<BookedStockItems>();
                foreach (var item in stockItems)
                {
                    booking.Add(new BookedStockItems() {
                        StockId = item.Id,
                        BookedFor = customerOrderId,
                        BookedBy = employeeId
                    });
                    
                }

                return booking;
        }
    }
}