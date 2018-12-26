/*
 * @CreateTime: Dec 23, 2018 11:47 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 26, 2018 9:37 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Vendors.PurchaseTerms.Commands.Update {
    public class UpdatedVendorPurchaseTermDto : IRequest {
        public uint Id { get; set; }
        public uint VendorId { get; set; }
        public uint ItemId { get; set; }
        public string VendorProductId { get; set; }
        public uint? Priority { get; set; }
        public uint? Leadtime { get; set; }
        public float? MinimumQuantity { get; set; }
        public float UnitPrice { get; set; }

    }
}