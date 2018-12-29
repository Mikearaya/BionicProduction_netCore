/*
 * @CreateTime: Dec 24, 2018 12:50 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 29, 2018 9:56 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Vendors.PurchaseTerms.Models;
using BionicInventory.Domain.Procurment.Vendors;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Vendors.PurchaseTerms.Queries.Single {
    public class GetPurchaseTermByIdQueryHandler
        : IRequestHandler<GetPurchaseTermByIdQuery, VendorPurchaseTermView> {
            private readonly IInventoryDatabaseService _database;

            public GetPurchaseTermByIdQueryHandler (IInventoryDatabaseService database) {
                _database = database;
            }

            public async Task<VendorPurchaseTermView> Handle (GetPurchaseTermByIdQuery request, CancellationToken cancellationToken) {

                var purchaseTerm = await _database.VendorPurchaseTerm
                    .Where (t => t.Id == request.Id)
                    .Select (VendorPurchaseTermView.Projection)
                    .FirstOrDefaultAsync ();

                if (purchaseTerm == null) {
                    throw new NotFoundException (nameof (VendorPurchaseTerm), request.Id);
                }

                return purchaseTerm;
            }

        }
}