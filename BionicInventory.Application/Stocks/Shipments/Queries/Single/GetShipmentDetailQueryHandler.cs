/*
 * @CreateTime: Feb 15, 2019 10:38 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 15, 2019 10:41 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Stocks.Shipments.Models;
using BionicInventory.Domain.Shipments;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Stocks.Shipments.Queries.Single {
    public class GetShipmentDetailQueryHandler : IRequestHandler<GetShipmentDetailQuery, ShipmentDetailModel> {
        private readonly IInventoryDatabaseService _database;

        public GetShipmentDetailQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<ShipmentDetailModel> Handle (GetShipmentDetailQuery request, CancellationToken cancellationToken) {
            var shipment = await _database.Shipment
                .Where (s => s.Id == request.Id)
                .Select (ShipmentDetailModel.Projection)
                .FirstOrDefaultAsync ();

            if (shipment == null) {
                throw new NotFoundException (nameof (Shipment), request.Id);
            }

            return shipment;
        }
    }
}