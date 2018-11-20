/*
 * @CreateTime: Nov 15, 2018 7:23 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 18, 2018 8:37 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Shipments.Models.ViewModels;
using BionicInventory.Domain.FinishedProducts;
using BionicInventory.Domain.Shipments;

namespace BionicInventory.Application.Shipments.Interfaces {
        public interface IShipmentQuery {

            IEnumerable<Shipment> GetAllShipments ();
            Shipment GetShipmentById (uint id);

            IEnumerable<ShipmentsSummaryView> GetCustomerOrderShipmentsSummary (uint customerOrderId);

            IEnumerable<Shipment> GetCustomerOrderShipments (uint customerOrderId);

            IEnumerable<ShipmentStatusView> GetAllShipmentStatus ();

            IEnumerable<CustomerOrderShipmentDetail> GetCustomerOrderShipmentStatus (uint customerOrderId);

            List<FinishedProduct> GetUnshipedCustomerOrderItems (uint orderItemId, int quantity);

            ShipmentDetailView GetShipmentDetails(uint shipmentId);
    

            }
        }