/*
 * @CreateTime: Nov 15, 2018 7:32 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 15, 2018 7:53 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Shipments.Interfaces;
using BionicInventory.Application.Shipments.Models;
using BionicInventory.Domain.Shipments;
using BionicInventory.Domain.Shipments.ShipmentDetails;

namespace BionicInventory.Application.Shipments.Factories {
    public class ShipmentFactory : IShipmentFactory {
        private readonly IShipmentQuery _query;

        public ShipmentFactory (IShipmentQuery query) {
            _query = query;
        }

        public Shipment CreateNewShipment (NewShipmentDto newShipment) {
            Shipment shipmentModel = new Shipment () {
                CustomerOrderId = newShipment.customerOrderId,
                BookedBy = newShipment.bookedBy,
                ShipmentNote = newShipment.shipmentNote,
                DeliveryDate = newShipment.deliveryDate,
            };
            foreach (var item in newShipment.ShipmentItems) {
                var stockItems = _query.GetUnshipedCustomerOrderItems (item.CustomerOrderItemId, item.Quantity);

                foreach (var stock in stockItems) {

                    shipmentModel.ShipmentDetail.Add (new ShipmentDetail () {
                        OrderItemId = item.CustomerOrderItemId,
                            Stock = stock,
                    });
                }
            }
            return shipmentModel;

        }
    }
}