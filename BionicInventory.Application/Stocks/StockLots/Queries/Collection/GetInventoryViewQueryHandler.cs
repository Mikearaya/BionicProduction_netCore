/*
 * @CreateTime: Jan 6, 2019 1:22 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 8:41 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Stocks.StockLots.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Stocks.StockLots.Queries.Collection {
    public class GetInventoryViewQueryHandler : IRequestHandler<GetInventoryViewQuery, IEnumerable<InventoryView>> {
        private readonly IInventoryDatabaseService _database;

        public GetInventoryViewQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public Task<IEnumerable<InventoryView>> Handle (GetInventoryViewQuery request, CancellationToken cancellationToken) {
            var result = _database.Item.Include (u => u.Group)
                .Include (u => u.PrimaryUom)
                .GroupJoin (_database.StockBatchStorage, product => product.Id,
                    manufOrder => manufOrder.Batch.ItemId,
                    (product, manufactureOrder) => new {
                        item = product,
                            lot = manufactureOrder,

                    }).GroupBy (manuf => manuf.item)
                .Select (i => new InventoryView () {

                    itemId = i.Key.Id,

                        itemCode = i.Key.Code,

                        item = i.Key.Name,
                        itemGroup = i.Key.Group.GroupName,
                        itemGroupId = i.Key.GroupId,
                        uom = i.Key.PrimaryUom.Abrivation,
                        quantity = i.Sum (l => l.lot.Where (s => s.Batch.Status.ToUpper () == "RECIEVED").Sum (q => q.Quantity)),
                        totalWriteOffs = i.Sum (l => l.lot.Where (s => s.Batch.Status.ToUpper () == "RECIEVED").Sum (q => q.Quantity * q.Batch.UnitCost)),
                        totalCost = i.Sum (l => l.lot.Where (s => s.Batch.Status.ToUpper () == "RECIEVED").Sum (q => q.Quantity * q.Batch.UnitCost)),

                        dateAdded = i.Key.DateAdded,
                        dateUpdated = i.Key.DateUpdate

                }).ToList ();

            return Task.FromResult<IEnumerable<InventoryView>> (result);

        }
    }
}