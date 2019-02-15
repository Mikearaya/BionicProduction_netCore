/*
 * @CreateTime: Feb 15, 2019 10:22 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 15, 2019 10:28 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using BionicInventory.Domain.Shipments;

namespace BionicInventory.Application.Stocks.Shipments.Models {
    public class ShipmentDetailItemModel {
        public uint Id { get; set; }
        public uint ShipmentId { get; set; }
        public uint LotBookingId { get; set; }
        public uint LotId { get; set; }
        public uint StorageId { get; set; }
        public string storage { get; set; }
        public float BookedQuantity { get; set; }
        public float? PickedQuantity { get; set; }

        public static Expression<Func<ShipmentDetail, ShipmentDetailItemModel>> Projection {
            get {
                return detail => new ShipmentDetailItemModel () {
                    Id = detail.Id,
                    ShipmentId = detail.ShipmentId,
                    LotBookingId = detail.LotBookingId,
                    StorageId = detail.LotBooking.BatchStorage.StorageId,
                    LotId = detail.LotBooking.BatchStorage.BatchId,
                    BookedQuantity = detail.BookedQuantity,
                    PickedQuantity = detail.PickedQuantity,
                    storage = detail.LotBooking.BatchStorage.Storage.Name
                };
            }
        }
    }
}