/*
 * @CreateTime: Dec 24, 2018 12:50 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 24, 2018 12:53 AM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Vendors.PurchaseTerms.Models;
using BionicInventory.Domain.Vendors;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Vendors.PurchaseTerms.Queries.Single {
    public class GetVendorPurchaseTermByIdQueryHandler
        : IRequestHandler<GetVendorPurchaseTermById, VendorPurchaseTermView> {
            private readonly IInventoryDatabaseService _database;

            public GetVendorPurchaseTermByIdQueryHandler (IInventoryDatabaseService database) {
                _database = database;
            }

            public async Task<VendorPurchaseTermView> Handle (GetVendorPurchaseTermById request, CancellationToken cancellationToken) {

                var purchaseTerm = await _database.VendorPurchaseTerm
                    .Select (VendorPurchaseTermView.Projection)
                    .FirstOrDefaultAsync (t => t.id == request.Id);

                if (purchaseTerm == null) {
                    throw new NotFoundException (nameof (VendorPurchaseTerm), request.Id);
                }

                return purchaseTerm;
            }

        }
}