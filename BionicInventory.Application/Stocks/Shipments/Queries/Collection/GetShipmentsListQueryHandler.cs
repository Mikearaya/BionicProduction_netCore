/*
 * @CreateTime: Feb 15, 2019 9:23 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 15, 2019 9:26 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Stocks.Shipments.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Stocks.Shipments.Queries.Collection {
    public class GetShipmentsListQueryHandler : IRequestHandler<GetShipmentsLIstQuery, IEnumerable<ShipmentsListModel>> {
        private readonly IInventoryDatabaseService _database;

        public GetShipmentsListQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<ShipmentsListModel>> Handle (GetShipmentsLIstQuery request, CancellationToken cancellationToken) {
            return await _database.Shipment
                .Select (ShipmentsListModel.Projection)
                .ToListAsync ();
        }
    }
}