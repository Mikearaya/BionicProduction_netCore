/*
 * @CreateTime: Dec 24, 2018 12:37 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 24, 2018 12:40 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Vendors.PurchaseTerms.Models;
using BionicInventory.Domain.Vendors;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Vendors.PurchaseTerms.Queries.Collections {
    public class GetItemPurchaseTermsListQueryHandler
        : IRequestHandler<GetItemPurchaseTermsListQuery, IEnumerable<VendorPurchaseTermView>> {
            private readonly IInventoryDatabaseService _database;

            public GetItemPurchaseTermsListQueryHandler (IInventoryDatabaseService database) {
                _database = database;
            }

            public async Task<IEnumerable<VendorPurchaseTermView>> Handle (GetItemPurchaseTermsListQuery request, CancellationToken cancellationToken) {
                var purchaseTerm = await _database.VendorPurchaseTerm
                    .AsNoTracking ()
                    .Where (t => t.ItemId == request.ItemId)
                    .Select (VendorPurchaseTermView.Projection)
                    .ToListAsync ();

                if (purchaseTerm == null) {
                    throw new NotFoundException ($" {nameof (VendorPurchaseTerm)} Item", request.ItemId);
                }

                return purchaseTerm;
            }
        }
}