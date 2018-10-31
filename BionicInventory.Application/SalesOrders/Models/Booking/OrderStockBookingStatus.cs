/*
 * @CreateTime: Nov 1, 2018 12:06 AM
 * @Author: undefined
 * @Contact: undefined
 * @Last Modified By: undefined
 * @Last Modified Time: Nov 1, 2018 12:11 AM
 * @Description: Modify Here, Please 
 */
namespace BionicInventory.Application.SalesOrders.Models.Booking {
    public class OrderStockBookingStatus {
        public uint Id { get; set; }
        public uint Booked { get; set; }
        public uint Remaining { get; set; }
        public uint Required { get; set; }
        public uint InProduction { get; set; }

    }
}