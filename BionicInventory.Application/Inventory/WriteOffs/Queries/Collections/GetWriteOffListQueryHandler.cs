/*
 * @CreateTime: Jan 1, 2019 10:07 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 1, 2019 10:09 PM
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

namespace BionicInventory.Application.Inventory.WriteOffs.Queries.Collections {
    public class GetWriteOffListQueryHandler : IRequestHandler<GetWriteOffsListQuery, IEnumerable<WriteOffItemListView>> {
        private readonly IInventoryDatabaseService _database;

        public GetWriteOffListQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<WriteOffItemListView>> Handle (GetWriteOffsListQuery request, CancellationToken cancellationToken) {
            return await _database.WriteOffDetail
                .Select (WriteOffItemListView.Projection)
                .ToListAsync ();
        }
    }
}