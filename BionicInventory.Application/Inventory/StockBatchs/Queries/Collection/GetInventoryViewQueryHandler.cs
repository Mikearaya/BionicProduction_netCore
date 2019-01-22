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
            var stock = await _database.Item.GroupJoin (_database.StockBatchStorage, product => product.Id,
                manufOrder => manufOrder.Batch.ItemId,
                (product, manufactureOrder) => new InventoryView () {

                    itemId = product.Id,

                        itemCode = product.Code,

                        item = product.Name,
                        itemGroup = product.Group.GroupName,
                        itemGroupId = product.GroupId,
                        uom = product.PrimaryUom.Abrivation,

                        quantity = manufactureOrder.Where (i => i.Batch.Status.ToUpper () == "RECIEVED").GroupBy (i => i.Batch.ItemId)
                        .Sum (MO => MO.Sum (f => f.Quantity)),
                        totalWriteOffs = manufactureOrder.Sum (w => w.WriteOffDetail.GroupBy (t => t.WriteOff.ItemId).Sum (e => e.Sum (q => q.Quantity))),
                        totalCost = manufactureOrder
                        .Where (MO => MO.Batch.Status.ToUpper () == "RECIEVED").Sum (MO => MO.Batch.UnitCost *
                            (MO.Quantity - (MO.WriteOffDetail.GroupBy (m => m.WriteOff.Item).Sum (q => q.Sum (s => s.Quantity))))),

                        dateAdded = product.DateAdded,
                        dateUpdated = product.DateUpdate
                }).GroupBy (manuf => manuf.itemId).ToListAsync ();

            List<InventoryView> stockStatus = new List<InventoryView> ();
            foreach (var item in stock) {
                foreach (var status in item) {
                    stockStatus.Add (status);

                }
            }

            return stockStatus;
        }
    }
}