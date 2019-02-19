/*
 * @CreateTime: Jan 30, 2019 8:29 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 8:56 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Products.Models;
using BionicInventory.Application.Stocks.Items.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Stocks.Items.Queries.Collections {
    public class GetCriticalItemsListQueryHandler : IRequestHandler<GetCriticalItemsListQuery, IEnumerable<CriticalItemsView>> {
        private readonly IInventoryDatabaseService _database;

        public GetCriticalItemsListQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public Task<IEnumerable<CriticalItemsView>> Handle (GetCriticalItemsListQuery request, CancellationToken cancellationToken) {
            var result = _database.Item
                .Include (i => i.PrimaryUom)
                .GroupJoin (_database.StockBatchStorage, item => item.Id,
                    lot => lot.Batch.ItemId,
                    (product, slot) => new ItemLotJoin () {
                        Item = product,
                            Lot = slot
                    }).GroupBy (i => i.Item)
                .Select (CriticalItemsView.Projection);

            if (request.Type.ToUpper () == "ALL") {
                result = result.Where (k => k.required > 0).AsQueryable ();
            } else {
                result = result.Where (k => k.required > 0 && k.type.ToUpper () == "PURCHASED").AsQueryable ();
            }

            return Task.FromResult<IEnumerable<CriticalItemsView>> (result);
        }
    }
}