using System.Collections.Generic;
using BionicInventory.Application.Shipments.Models;
using BionicInventory.Application.Shipments.Models.ViewModels;
using BionicInventory.Domain.Shipments;

namespace BionicInventory.Application.Shipments.Interfaces {
    public interface IShipmentFactory {
        Shipment CreateNewShipment (NewShipmentDto newShipment);

        IEnumerable<ShipmentItemStatusView> CreateShipmentSummary (Shipment newShipment);
    }
}