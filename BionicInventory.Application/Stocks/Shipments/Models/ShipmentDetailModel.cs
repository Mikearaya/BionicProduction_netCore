/*
 * @CreateTime: Feb 15, 2019 8:41 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 15, 2019 10:37 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BionicInventory.Domain.Shipments;

namespace BionicInventory.Application.Stocks.Shipments.Models {
    public class ShipmentDetailModel {
        public uint Id { get; set; }
        public string Status { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public IEnumerable<ShipmentDetailItemModel> ShipmentDetail { get; set; } = new List<ShipmentDetailItemModel> ();

        public static Expression<Func<Shipment, ShipmentDetailModel>> Projection {
            get {
                return shipment => new ShipmentDetailModel () {
                    Id = shipment.Id,
                    Status = shipment.Status,
                    DeliveryDate = shipment.DeliveryDate,
                    DateAdded = shipment.DateAdded,
                    DateUpdated = shipment.DateUpdated,
                    ShipmentDetail = shipment.ShipmentDetail.AsQueryable ().Select (ShipmentDetailItemModel.Projection)
                };
            }
        }

    }
}