/*
 * @CreateTime: Dec 23, 2018 11:48 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 23, 2018 11:49 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicInventory.Application.Vendors.PurchaseTerms.Commands.Delete {
    public class DeletedVendorPurchaseTermDto : IRequest {
        public uint Id { get; set; }

    }
}