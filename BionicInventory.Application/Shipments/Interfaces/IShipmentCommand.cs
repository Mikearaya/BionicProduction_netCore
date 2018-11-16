/*
 * @CreateTime: Nov 15, 2018 7:22 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 15, 2018 7:23 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.Shipments;

namespace BionicInventory.Application.Shipments.Interfaces {
    public interface IShipmentCommand {
        Shipment CreateShipment (Shipment newShipment);
        bool UpdateShipment (Shipment updatedShipment);
        bool DeleteShipment (Shipment deletedShipment);
    }
}