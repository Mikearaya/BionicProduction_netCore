using BionicInventory.Application.Shipments.Models;
using BionicInventory.Domain.Shipments;

namespace BionicInventory.Application.Shipments.Interfaces {
    public interface IShipmentFactory {
        Shipment CreateNewShipment (NewShipmentDto newShipment);
    }
}