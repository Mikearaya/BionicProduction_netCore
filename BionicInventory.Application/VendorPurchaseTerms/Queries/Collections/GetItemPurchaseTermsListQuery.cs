/*
 * @CreateTime: Dec 24, 2018 12:35 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 24, 2018 12:36 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Vendors.PurchaseTerms.Models;
using MediatR;

namespace BionicInventory.Application.Vendors.PurchaseTerms.Queries.Collections {
    public class GetItemPurchaseTermsListQuery : IRequest<IEnumerable<VendorPurchaseTermView>> {
        public uint ItemId { get; set; }
    }
}