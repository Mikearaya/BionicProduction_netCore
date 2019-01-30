/*
 * @CreateTime: Jan 30, 2019 7:46 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 7:46 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Stocks.Items.Models;
using BionicInventory.Domain.Items;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Stocks.Items.Queries.Single {
    public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, ItemView> {
        private readonly IInventoryDatabaseService _database;

        public GetItemByIdQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<ItemView> Handle (GetItemByIdQuery request, CancellationToken cancellationToken) {
            var item = await _database.Item
                .Where (i => i.Id == request.Id)
                .Select (ItemView.Projection)
                .FirstOrDefaultAsync ();

            if (item == null) {
                throw new NotFoundException (nameof (Item), request.Id);
            }
            return item;
        }
    }
}