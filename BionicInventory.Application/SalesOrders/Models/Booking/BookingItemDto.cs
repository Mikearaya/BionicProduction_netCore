using System.Collections.Generic;

namespace BionicInventory.Application.SalesOrders.Models.Booking {

public class BookingItemDto {
    public uint ItemId {get; set;}
    public uint quantity {get; set; }
    public uint CustomerOrderItemId {get; set;}

}

}