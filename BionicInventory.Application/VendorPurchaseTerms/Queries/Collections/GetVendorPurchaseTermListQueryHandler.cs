/*
 * @CreateTime: Dec 24, 2018 12:27 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 29, 2018 9:57 PM
 * @Description: Modify Here, Please 
 */
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
    public class GetVendorPurchaseTermListQueryHandler
        : IRequestHandler<GetVendorPurchaseTermListQuery, IEnumerable<VendorPurchaseTermView>> {
            private readonly IInventoryDatabaseService _database;

            public GetVendorPurchaseTermListQueryHandler (IInventoryDatabaseService database) {
                _database = database;
            }

            public async Task<IEnumerable<VendorPurchaseTermView>> Handle (GetVendorPurchaseTermListQuery request, CancellationToken cancellationToken) {

                var purchaseTerm = await _database.VendorPurchaseTerm
                    .AsNoTracking ()
                    .Where (t => t.VendorId == request.VendorId)
                    .Select (VendorPurchaseTermView.Projection)
                    .ToListAsync ();

                if (purchaseTerm == null) {
                    throw new NotFoundException (nameof (VendorPurchaseTerm), request.VendorId);
                }

                return purchaseTerm;
            }
        }
}