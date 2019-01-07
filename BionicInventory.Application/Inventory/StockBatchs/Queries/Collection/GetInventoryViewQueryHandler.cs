/*
 * @CreateTime: Jan 6, 2019 1:22 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 6, 2019 2:01 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Inventory.StockBatchs.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Inventory.StockBatchs.Queries.Collection {
    public class GetInventoryViewQueryHandler : IRequestHandler<GetInventoryViewQuery, IEnumerable<InventoryView>> {
        private readonly IInventoryDatabaseService _database;

        public GetInventoryViewQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<InventoryView>> Handle (GetInventoryViewQuery request, CancellationToken cancellationToken) {
            return await _database.Item
                .GroupJoin (_database.StockBatchStorage
                    .Where (s => s.Batch.Status.Trim ().ToUpper () == "RECIEVED"),
                    i => i.Id,
                    b => b.Batch.ItemId,
                    (item, batch) => new ItemBatchJoin () {
                        Batch = batch,
                            Item = item,
                            totalWriteOffs = batch.GroupBy (d => d.BatchId)
                            .Sum (im => im.Where (o => o.WriteOffDetail != null).Sum (w => w.WriteOffDetail.Sum (e => e.Quantity))),
                    })
                .Select (InventoryView.Projection)
                .ToListAsync ();
        }
    }
}