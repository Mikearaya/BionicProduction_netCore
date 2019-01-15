/*
 * @CreateTime: Jan 15, 2019 12:09 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 15, 2019 12:21 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Products.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Products.Queries {
    public class GetVendorItemsListQueryHandler : IRequestHandler<GetVendorItemsList, IEnumerable<VendorItemViewModel>> {
        private readonly IInventoryDatabaseService _database;

        public GetVendorItemsListQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<VendorItemViewModel>> Handle (GetVendorItemsList request, CancellationToken cancellationToken) {

            return await _database.VendorPurchaseTerm
                .Where (v => v.VendorId == request.VendorId)
                .Select (VendorItemViewModel.Projection)
                .ToListAsync ();
        }
    }
}