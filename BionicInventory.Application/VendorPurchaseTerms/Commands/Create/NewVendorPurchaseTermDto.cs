/*
 * @CreateTime: Dec 23, 2018 11:45 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 23, 2018 11:45 PM
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
        public float? MinimumQuantity { get; set; }
        public float UnitPrice { get; set; }
    }
}