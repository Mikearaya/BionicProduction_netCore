/*
 * @CreateTime: Dec 4, 2018 10:23 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 6, 2018 12:06 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Products.BOMs.Models;
using BionicInventory.Application.Shared;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Items;
using BionicInventory.Domain.Items.BOMs;
using MediatR;

namespace BionicInventory.Application.Products.BOMs.Commands.Create {
    public class CreateNewBomItemHandler : IRequestHandler<NewBomDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public CreateNewBomItemHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (NewBomDto request, CancellationToken cancellationToken) {
            var item = await _database.Item.FindAsync (request.ItemId);

            if (item == null) {
                throw new NotFoundException (nameof (Item), request.ItemId);
            }
            Bom newBom = new Bom () {
                ItemId = request.ItemId,
                Active = request.Active,
                Name = request.Name
            };

            if (request.BomItems.Count < 1) {
                throw new BelowRequiredMinimumItemException (nameof (BomItems), 1, nameof (Item));
            }

            foreach (var data in request.BomItems) {

                var bomItem = await _database.Item.FindAsync (data.ItemId);

                if (bomItem == null) {
                    throw new NotFoundException (nameof (Item), data.ItemId);
                }

                var uomId = await _database.UnitsOfMeasurment.FindAsync (data.UomId);
                
                if (uomId == null) {
                    throw new NotFoundException (nameof (UnitOfMeasurment), data.UomId);
                }

                newBom.BomItems.Add (new BomItems () {
                    ItemId = data.ItemId,
                        Quantity = data.Quantity,
                        UomId = data.UomId,
                        Note = data.Note
                });

            }

            _database.Bom.Add (newBom);

            await _database.SaveAsync ();

            return Unit.Value;
        }

        private object UnitOfMeasurment () {
            throw new NotImplementedException ();
        }
    }
}