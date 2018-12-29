using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Vendors.PurchaseTerms.Models;
using BionicInventory.Domain.Procurment.Vendors;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Vendors.PurchaseTerms.Queries.Collections {
    public class GetVendorItemPurchaseTermsQueryHandler
        : IRequestHandler<GetVendorItemPurchaseTermsQuery, IEnumerable<VendorPurchaseTermView>> {
            private readonly IInventoryDatabaseService _database;

            public GetVendorItemPurchaseTermsQueryHandler (IInventoryDatabaseService database) {
                _database = database;
            }

            public async Task<IEnumerable<VendorPurchaseTermView>> Handle (GetVendorItemPurchaseTermsQuery request, CancellationToken cancellationToken) {

                var purchaseTerm = await _database.VendorPurchaseTerm
                    .AsNoTracking ()
                    .Where (t => t.VendorId == request.VendorId && t.ItemId == request.ItemId)
                    .Select (VendorPurchaseTermView.Projection)
                    .ToListAsync ();

                if (purchaseTerm == null) {
                    throw new NotFoundException (nameof (VendorPurchaseTerm), request.VendorId);
                }

                return purchaseTerm;
            }
        }
}