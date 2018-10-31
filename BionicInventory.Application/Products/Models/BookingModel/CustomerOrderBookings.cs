/*
 * @CreateTime: Oct 23, 2018 8:29 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 24, 2018 11:02 PM
 * @Description: Modify Here, Please 
 */


using System.Collections.Generic;

namespace BionicInventory.Application.Products.Models.BookingModel {

public class CustomerOrderBookings {
    public uint id {set; get;}
    public string customer {get; set;}

    public List<BookedOrderItemDetail> orderItems {get; set;} = new List<BookedOrderItemDetail>();
    
}

}
