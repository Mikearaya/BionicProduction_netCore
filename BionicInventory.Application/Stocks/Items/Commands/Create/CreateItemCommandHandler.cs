using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Stocks.Items.Models;
using BionicInventory.Domain.Items;
using BionicInventory.Domain.Storages;
using BionicInventory.Domain.UnitOfMeasurments;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Stocks.Items.Commands.Create {
    public class CreateItemCommandHandler : IRequestHandler<NewItemDto, uint> {
        private readonly IInventoryDatabaseService _database;

        public CreateItemCommandHandler (IInventoryDatabaseService database) {
            _database = database;

        }

        public async Task<uint> Handle (NewItemDto request, CancellationToken cancellationToken) {
            var uom = await _database.UnitsOfMeasurment
                .AsNoTracking ()
                .FirstOrDefaultAsync (u => u.Id == request.primaryUomId);

            if (uom == null) {
                throw new NotFoundException (nameof (UnitOfMeasurment), request.primaryUomId);
            }

            var itemGroup = await _database.ProductGroup
                .AsNoTracking ()
                .FirstOrDefaultAsync (u => u.Id == request.primaryUomId);

            if (itemGroup == null) {
                throw new NotFoundException (nameof (ProductGroup), request.groupId);
            }

            var storage = await _database.StorageLocation
                .AsNoTracking ()
                .FirstOrDefaultAsync (u => u.Id == request.DefaultStorageId);

            if (itemGroup == null) {
                throw new NotFoundException (nameof (StorageLocation), request.DefaultStorageId);
            }

            Item newItem = new Item () {
                Name = request.name,
                Code = request.code,
                Weight = request.weight,
                UnitCost = request.unitCost,
                Photo = request.image,
                MinimumQuantity = request.MinimumQuantity,
                GroupId = request.groupId,
                ShelfLife = request.shelfLife,
                IsInventory = request.isInventoryItem,
                IsProcured = request.isProcured,
                PrimaryUomId = request.primaryUomId,
                Price = request.price,
                DefaultStorageId = request.DefaultStorageId

            };

            _database.Item.Add (newItem);
            await _database.SaveAsync ();

            return newItem.Id;

        }
    }
}