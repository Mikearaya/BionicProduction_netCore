/*
 * @CreateTime: Dec 23, 2018 11:45 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 15, 2019 12:39 AM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Vendors.PurchaseTerms.Commands.Create {
    public class NewVendorPurchaseTermDto : IRequest<uint> {
        public uint VendorId { get; set; }
        public uint ItemId { get; set; }
        public string VendorProductId { get; set; }
        public uint? Priority { get; set; }
        public uint? Leadtime { get; set; }
        public uint? MinimumQuantity { get; set; }
        public float UnitPrice { get; set; }
    }
}