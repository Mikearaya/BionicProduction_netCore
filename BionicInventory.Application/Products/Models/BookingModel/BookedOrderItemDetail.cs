/*
 * @CreateTime: Oct 23, 2018 8:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 24, 2018 11:02 PM
 * @Description: Modify Here, Please 
 */



namespace BionicInventory.Application.Products.Models.BookingModel {

public class BookedOrderItemDetail {
    public uint id {get; set;}
    public string productName { get; set;}
    public float availableAmount {get; set;}
    public float inStock {get; set;}
    public float bookedAmount {get; set;}
    public float afterBooking {get; set;}
    public float neededAmount {get; set;}
    public float remainingAmount {get; set;}
}

}