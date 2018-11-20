/*
 * @CreateTime: Nov 15, 2018 8:59 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 15, 2018 8:59 PM
 * @Description: Modify Here, Please 
 */
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Shipments.Interfaces;
using BionicInventory.Domain.Shipments;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Shipments.Commands {
    public class ShipmentCommand : IShipmentCommand {
        private readonly IInventoryDatabaseService _database;
        private readonly ILogger<ShipmentCommand> _logger;

        public ShipmentCommand (IInventoryDatabaseService database,
            ILogger<ShipmentCommand> logger) {
            _database = database;
            _logger = logger;
        }

        public Shipment CreateShipment (Shipment newShipment) {
            _database.Shipment.Add (newShipment);
            _database.Save ();
            return newShipment;
        }

        public bool DeleteShipment (Shipment deletedShipment) {
            _database.Shipment.Remove (deletedShipment);
            _database.Save ();
            return true;
        }

        public Shipment PickShipment(Shipment shipment)
        {
            foreach (var item in shipment.ShipmentDetail)
            {
                item.Picked = 1;
            }

            _database.Shipment.Update(shipment);
            _database.Save();
            return shipment;
        }

        public bool UpdateShipment (Shipment updatedShipment) {
            _database.Shipment.Update (updatedShipment);
            _database.Save ();
            return true;
        }
    }
}