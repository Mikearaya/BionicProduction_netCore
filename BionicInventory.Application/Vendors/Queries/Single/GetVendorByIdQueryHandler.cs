/*
 * @CreateTime: Dec 24, 2018 9:04 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 24, 2018 9:14 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Vendors.Models;
using BionicInventory.Domain.Vendors;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Vendors.Queries.Single {
    public class GetVendorByIdQueryHandler : IRequestHandler<GetVendorByIdQuery, VendorView> {
        private readonly IInventoryDatabaseService _database;

        public GetVendorByIdQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<VendorView> Handle (GetVendorByIdQuery request, CancellationToken cancellationToken) {

            var vendor = await _database.Vendor
                .Select (VendorView.Projection)
                .FirstOrDefaultAsync (v => v.id == request.Id);

            if (vendor == null) {
                throw new NotFoundException (nameof (Vendor), request.Id);
            }

            return vendor;
        }
    }
}