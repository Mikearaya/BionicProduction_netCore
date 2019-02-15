/*
 * @CreateTime: Feb 15, 2019 8:50 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 15, 2019 8:59 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Stocks.Shipments.Models;
using BionicInventory.Domain.Shipments;
using BionicProduction.Domain.StockBatchs;
using MediatR;

namespace BionicInventory.Application.Stocks.Shipments.Commands.Create {
    public class CreateShipmentCommandHandler : IRequestHandler<NewShipmentDto, uint> {
        private readonly IInventoryDatabaseService _database;

        public CreateShipmentCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<uint> Handle (NewShipmentDto request, CancellationToken cancellationToken) {
            Shipment newShipment = new Shipment () {
                Status = request.Status.Trim (),
                DeliveryDate = request.DeliveryDate,
            };

            foreach (var item in request.ShipmentDetail) {
                var booking = await _database.BookedStockBatch.FindAsync (item.LotBookingId);

                if (booking == null) {
                    throw new NotFoundException (nameof (BookedStockBatch), item.LotBookingId);
                }

                newShipment.ShipmentDetail.Add (new ShipmentDetail () {
                    BookedQuantity = item.Quantity,
                        LotBookingId = item.LotBookingId,

                });
            }

            _database.Shipment.Add (newShipment);

            await _database.SaveAsync ();

            return newShipment.Id;
        }
    }
}