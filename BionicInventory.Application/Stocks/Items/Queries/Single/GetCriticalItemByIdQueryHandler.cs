/*
 * @CreateTime: Jan 30, 2019 8:00 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 8:56 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Products.Models;
using BionicInventory.Application.Stocks.Items.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Stocks.Items.Queries.Single {
    public class GetCriticalItemByIdQueryHandler : IRequestHandler<GetCriticalItemByIdQuery, CriticalItemsView> {
        private readonly IInventoryDatabaseService _database;

        public GetCriticalItemByIdQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public Task<CriticalItemsView> Handle (GetCriticalItemByIdQuery request, CancellationToken cancellationToken) {
            var result = _database.Item
                .Include (i => i.PrimaryUom)
                .GroupJoin (_database.StockBatchStorage, item => item.Id,
                    lot => lot.Batch.ItemId,
                    (product, lot) => new ItemLotJoin () {
                        Item = product,
                            Lot = lot
                    }).GroupBy (i => i.Item)
                .Select (CriticalItemsView.Projection)
                .Where (k => k.required > 0)
                .FirstOrDefault (i => i.id == request.Id);

            return Task.FromResult<CriticalItemsView> (result);

        }
    }
}