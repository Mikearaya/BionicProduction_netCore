/*
 * @CreateTime: Jan 4, 2019 7:13 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 4, 2019 7:19 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Inventory.WriteOffs.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Inventory.WriteOffs.Queries.Single {
    public class GetItemWriteOffsByIdQueryHandler : IRequestHandler<GetItemWriteOffsByIdQuery, IEnumerable<WriteOffItemListView>> {
        private readonly IInventoryDatabaseService _database;

        public GetItemWriteOffsByIdQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<WriteOffItemListView>> Handle (GetItemWriteOffsByIdQuery request, CancellationToken cancellationToken) {
            return await _database.WriteOffDetail.Where (i => i.BatchStorage.Batch.ItemId == request.ItemId)
                .Select (WriteOffItemListView.Projection)
                .ToListAsync ();
        }
    }
}