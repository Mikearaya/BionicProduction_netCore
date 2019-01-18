/*
 * @CreateTime: Dec 24, 2018 12:48 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 26, 2018 9:09 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Vendors.PurchaseTerms.Models;
using MediatR;

namespace BionicInventory.Application.Vendors.PurchaseTerms.Queries.Single {
    public class GetPurchaseTermByIdQuery : IRequest<VendorPurchaseTermView> {
        public uint Id { get; set; }
    }
}