/*
 * @CreateTime: Jan 30, 2019 7:28 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 7:33 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Stocks.Items.Models;
using BionicInventory.Domain.Items;
using MediatR;

namespace BionicInventory.Application.Stocks.Items.Commands.Update {
    public class UpdateItemCommandHandler : IRequestHandler<UpdatedItemDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public UpdateItemCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (UpdatedItemDto request, CancellationToken cancellationToken) {
            var item = await _database.Item.FindAsync (request.id);

            if (item == null) {
                throw new NotFoundException (nameof (Item), request.id);
            }

            item.Name = request.name;
            item.UnitCost = request.unitCost;
            item.Photo = request.image;
            item.Weight = request.weight;
            item.IsProcured = request.isProcured;
            item.IsInventory = request.isInventoryItem;
            item.MinimumQuantity = request.MinimumQuantity;
            item.ShelfLife = request.shelfLife;

            _database.Item.Update (item);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}