/*
 * @CreateTime: Dec 16, 2018 11:55 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 17, 2018 12:09 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Items;
using BionicInventory.Domain.Items.BOMs;
using BionicInventory.Domain.Items.Rotings;
using BionicInventory.Domain.Routings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Routings.Commands.Update {
    public class UpdateRoutingCommandHandler : IRequestHandler<UpdatedRoutingDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public UpdateRoutingCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (UpdatedRoutingDto request, CancellationToken cancellationToken) {

            var updatedRouting = await _database.Routing
                .Include (r => r.RoutingOperation)
                .Include (r => r.RoutingBoms)
                .Where (r => r.Id == request.Id)
                .FirstOrDefaultAsync ();

            if (updatedRouting == null) {
                throw new NotFoundException (nameof (Routing), request.Id);
            }

            updatedRouting.ItemId = request.ItemId;
            updatedRouting.Name = request.Name;
            updatedRouting.Note = request.Note;
            updatedRouting.FixedCost = request.FixedCost;
            updatedRouting.VariableCost = request.VariableCost;
            updatedRouting.Quantity = request.Quantity;

            var itemObj = await _database.Item.FindAsync (request.ItemId);

            if (itemObj == null) {
                throw new NotFoundException (nameof (Item), request.ItemId);
            }

            updatedRouting.RoutingBoms = new List<RoutingBoms> ();
            foreach (var item in request.Boms) {
                var bom = await _database.Bom.FindAsync (item.BomId);

                if (bom == null) {
                    throw new NotFoundException (nameof (Bom), item.BomId);
                }

                updatedRouting.RoutingBoms.Add (new RoutingBoms () {
                    RoutingId = (item.RoutingId != 0) ? item.RoutingId : 0,
                        BomId = item.BomId
                });
            }

            //TODO check if operations have at least 1

            updatedRouting.RoutingOperation = new List<RoutingOperation> ();

            foreach (var item in request.Operations) {
                var workstationGroup = await _database.WorkStationGroup.FindAsync (item.WorkstationId);

                if (workstationGroup == null) {
                    throw new NotFoundException (nameof (workstationGroup), item.WorkstationId);
                }

                updatedRouting.RoutingOperation.Add (new RoutingOperation () {
                    RoutingId = (item.RoutingId != 0) ? item.RoutingId : 0,
                        WorkstationId = item.WorkstationId,
                        Operation = item.Operation,
                        FixedCost = item.FixedCost,
                        FixedTime = item.FixedTime,
                        VariableCost = item.VariableCost,
                        VariableTime = item.VariableTime,
                        Quantity = item.Quantity
                });
            }

            _database.Routing.Update (updatedRouting);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}