/*
 * @CreateTime: Jan 31, 2019 6:37 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 31, 2019 6:40 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Stocks.Items.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Stocks.Items.Queries.Collections {
    public class GetItemsReportQueryHandler : IRequestHandler<GetItemsReportQuery, IEnumerable<ItemReportListView>> {
        private readonly IInventoryDatabaseService _database;

        public GetItemsReportQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public Task<IEnumerable<ItemReportListView>> Handle (GetItemsReportQuery request, CancellationToken cancellationToken) {
            var result = _database.Item
                .Include (i => i.PrimaryUom)
                .GroupJoin (_database.StockBatchStorage, item => item.Id,
                    lot => lot.Batch.ItemId,
                    (product, slot) => new ItemLotJoin () {
                        Item = product,
                            Lot = slot
                    }).GroupBy (i => i.Item)
                .Select (ItemReportListView.Projection)
                .ToList ();

            return Task.FromResult<IEnumerable<ItemReportListView>> (result);
        }
    }
}