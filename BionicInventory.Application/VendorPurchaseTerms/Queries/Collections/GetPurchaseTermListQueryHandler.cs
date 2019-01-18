/*
 * @CreateTime: Dec 26, 2018 9:04 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 26, 2018 9:06 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Vendors.PurchaseTerms.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.VendorPurchaseTerms.Queries.Collections {
    public class GetPurchaseTermListQueryHandler : IRequestHandler<GetPurchaseTermsListQuery, IEnumerable<VendorPurchaseTermView>> {
        private readonly IInventoryDatabaseService _database;

        public GetPurchaseTermListQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<VendorPurchaseTermView>> Handle (GetPurchaseTermsListQuery request, CancellationToken cancellationToken) {

            return await _database.VendorPurchaseTerm
                .Select (VendorPurchaseTermView.Projection)
                .ToListAsync ();
        }
    }
}