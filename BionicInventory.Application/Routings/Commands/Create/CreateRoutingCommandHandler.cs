/*
 * @CreateTime: Dec 16, 2018 11:20 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 17, 2018 11:03 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.Items;
using BionicInventory.Domain.Items.BOMs;
using BionicInventory.Domain.Items.Rotings;
using BionicInventory.Domain.Routings;
using MediatR;

namespace BionicInventory.Application.Routings.Commands.Create {
    public class CreateRoutingCommandHandler : IRequestHandler<NewRoutingDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public CreateRoutingCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (NewRoutingDto request, CancellationToken cancellationToken) {

            Routing newRouting = new Routing () {
                Name = request.Name,
                Note = request.Note,
                FixedCost = request.FixedCost,
                VariableCost = request.VariableCost,
                Quantity = request.Quantity,
                ItemId = request.ItemId
            };

            var itemObj = await _database.Item.FindAsync (request.ItemId);

            if (itemObj == null) {
                throw new NotFoundException (nameof (Item), request.ItemId);
            }

            foreach (var item in request.Boms) {
                var bom = await _database.Bom.FindAsync (item.BomId);

                if (bom == null) {
                    throw new NotFoundException (nameof (Bom), item.BomId);
                }

                newRouting.RoutingBoms.Add (new RoutingBoms () {
                    BomId = item.BomId
                });
                
            }

            //TODO check if operations have at least 1

            foreach (var item in request.Operations) {
                var workstationGroup = await _database.WorkStationGroup.FindAsync (item.WorkstationId);

                if (workstationGroup == null) {
                    throw new NotFoundException (nameof (workstationGroup), item.WorkstationId);
                }

                newRouting.RoutingOperation.Add (new RoutingOperation () {
                    WorkstationId = item.WorkstationId,
                        Operation = item.Operation,
                        FixedCost = item.FixedCost,
                        FixedTime = item.FixedTime,
                        VariableCost = item.VariableCost,
                        VariableTime = item.VariableTime,
                        Quantity = item.Quantity
                });
            }

            _database.Routing.Add (newRouting);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}