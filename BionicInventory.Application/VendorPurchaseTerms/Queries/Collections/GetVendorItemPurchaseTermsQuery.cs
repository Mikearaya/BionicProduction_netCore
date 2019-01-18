/*
 * @CreateTime: Dec 24, 2018 12:41 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 24, 2018 12:43 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Vendors.PurchaseTerms.Models;
using MediatR;

namespace BionicInventory.Application.Vendors.PurchaseTerms.Queries.Collections {
    public class GetVendorItemPurchaseTermsQuery : IRequest<IEnumerable<VendorPurchaseTermView>> {

        public uint VendorId { get; set; }
        public uint ItemId { get; set; }

    }
}