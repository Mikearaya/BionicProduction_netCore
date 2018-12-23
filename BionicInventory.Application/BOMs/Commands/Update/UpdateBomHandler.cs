/*
 * @CreateTime: Dec 4, 2018 10:51 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 5, 2018 11:54 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Products.BOMs.Models;
using BionicInventory.Application.Shared;
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
            var item = await _database.Item.AsNoTracking ()
                .FirstOrDefaultAsync (i => i.Id == request.ItemId);

            var updatedBom = await _database.Bom
                .Include (b => b.BomItems)
                .FirstOrDefaultAsync (b => b.Id == request.Id);

            if (updatedBom == null) {
                throw new NotFoundException (nameof (Bom), request.Id);
            }

            if (item == null) {
                throw new NotFoundException (nameof (Item), request.ItemId);
            }
            updatedBom.ItemId = request.ItemId;
            updatedBom.Active = request.Active;
            updatedBom.Name = request.Name;


            if (request.BomItems.Count < 1) {
                throw new BelowRequiredMinimumItemException (nameof (BomItems), 1, nameof (Item));
            }

            updatedBom.BomItems = new List<BomItems> ();

            foreach (var data in request.BomItems) {
                BomItems bo = new BomItems ();
                if (data.Id != 0) {
                    bo = await _database.BomItems.FirstOrDefaultAsync (b => b.Id == data.Id);

                    if (bo == null) {
                        throw new NotFoundException (nameof (BomItems), data.Id);
                    }

                } else {
                    var bomItem = await _database.Item.AsNoTracking ()
                        .FirstOrDefaultAsync (i => i.Id == data.ItemId);

                    if (bomItem == null) {
                        throw new NotFoundException (nameof (Item), data.ItemId);
                    }
                }

                var uomId = await _database.UnitsOfMeasurment.AsNoTracking ()
                    .FirstOrDefaultAsync (i => i.Id == data.UomId);

                if (uomId == null) {
                    throw new NotFoundException (nameof (UnitOfMeasurment), data.UomId);
                }

                bo.ItemId = data.ItemId;
                bo.Quantity = data.Quantity;
                bo.UomId = data.UomId;
                bo.Note = data.Note;
                bo.BomId = request.Id;
                updatedBom.BomItems.Add(bo);

            }
            _database.Bom.Update (updatedBom);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}