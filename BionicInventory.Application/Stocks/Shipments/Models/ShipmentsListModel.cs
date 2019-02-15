/*
 * @CreateTime: Feb 15, 2019 8:41 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 15, 2019 9:22 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using BionicInventory.Domain.Shipments;

namespace BionicInventory.Application.Stocks.Shipments.Models {
    public class ShipmentsListModel {

        public uint Id { get; set; }
        public string Status { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public static Expression<Func<Shipment, ShipmentsListModel>> Projection {
            get {
                return shipment => new ShipmentsListModel () {
                    Id = shipment.Id,
                    Status = shipment.Status,
                    DeliveryDate = shipment.DeliveryDate,
                    DateAdded = shipment.DateAdded,
                    DateUpdated = shipment.DateUpdated
                };
            }
        }

    }
}