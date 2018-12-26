using System.Collections.Generic;
using BionicInventory.Application.Vendors.PurchaseTerms.Models;
using MediatR;

namespace BionicInventory.Application.VendorPurchaseTerms.Queries.Collections {
    public class GetPurchaseTermsListQuery : IRequest<IEnumerable<VendorPurchaseTermView>> {

    }
}