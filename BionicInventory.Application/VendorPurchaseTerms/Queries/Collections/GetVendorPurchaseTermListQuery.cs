/*
 * @CreateTime: Dec 24, 2018 12:26 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 24, 2018 12:28 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Vendors.PurchaseTerms.Models;
using MediatR;

namespace BionicInventory.Application.Vendors.PurchaseTerms.Queries.Collections {
    public class GetVendorPurchaseTermListQuery : IRequest<IEnumerable<VendorPurchaseTermView>> {
        public uint VendorId { get; set; }
    }
}