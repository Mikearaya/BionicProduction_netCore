/*
 * @CreateTime: Dec 4, 2018 10:51 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 5, 2018 1:05 AM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Products.BOMs.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Items;
using BionicInventory.Domain.Items.BOMs;
using BionicInventory.Domain.UnitOfMeasurments;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Products.BOMs.Commands.Update {
    public class UpdateBomHandler : IRequestHandler<UpdatedBomDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public UpdateBomHandler (IInventoryDatabaseService database) {
            _database = database;
        }
        public async Task<Unit> Handle (UpdatedBomDto request, CancellationToken cancellationToken) {
            var item = await _database.Item.FindAsync (request.ItemId);

            var bom = await _database.Bom.FindAsync (request.Id);

            if (bom == null) {
                throw new NotFoundException (nameof (Bom), request.Id);
            }

            if (item == null) {
                throw new NotFoundException (nameof (Item), request.ItemId);
            }
            Bom newBom = new Bom () {
                Id = request.Id,
                ItemId = request.ItemId,
                Active = request.Active,
                Name = request.Name
            };

            foreach (var data in request.BomItems) {
                var bomItem = await _database.Item.FindAsync (data.ItemId);

                var uomId = await _database.UnitsOfMeasurment.FindAsync (data.UomId);

                if (data.Id != 0) {
                    var bomItems = await _database.BomItems.AsNoTracking ().FirstOrDefaultAsync (b => b.Id == data.Id);

                    if (bomItems == null) {
                        throw new NotFoundException (nameof (BomItems), data.Id);
                    }

                }

                if (bomItem == null) {
                    throw new NotFoundException (nameof (Item), data.ItemId);
                }

                if (uomId == null) {
                    throw new NotFoundException (nameof (UnitOfMeasurment), data.UomId);
                }

                BomItems updatedItem = new BomItems () {
                    ItemId = data.ItemId,
                    Quantity = data.Quantity,
                    UomId = data.UomId,
                    Note = data.Note,
                    BomId = request.Id

                };

                if (data.Id != 0) {
                    updatedItem.Id = (uint) data.Id;
                }

                newBom.BomItems.Add (updatedItem);

            }

            _database.Bom.Update (newBom);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}