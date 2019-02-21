/*
 * @CreateTime: Feb 21, 2019 9:19 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 21, 2019 9:33 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq;
using System.Linq.Expressions;
using BionicInventory.Domain.CustomerOrders;

namespace BionicInventory.Application.CRM.CustomerOrders.Models {
    public class CustomerOrderItemView {
        public uint Id { get; set; }
        public uint ItemId { get; set; }
        public double Quantity { get; set; }
        public float UnitPrice { get; set; }
        public double SubTotal {
            get {
                return Quantity * UnitPrice;
            }
        }
        public double TotalCost { get; set; }
        public double Profit {
            get {
                return SubTotal - TotalCost;
            }
        }
        public string Status { get; set; }
        public uint ManufactureOrderId { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public float? TotalShipped { get; set; }

        public static Expression<Func<CustomerOrderItem, CustomerOrderItemView>> Projection {
            get {
                return order => new CustomerOrderItemView () {
                    Id = order.Id,
                    ItemId = order.ItemId,
                    Quantity = order.Quantity,
                    UnitPrice = order.PricePerItem,
                    TotalCost = order.BookedStockBatch.Sum (o => o.BatchStorage.Batch.UnitCost * order.Quantity),
                    TotalShipped = order.BookedStockBatch.Sum (o => o.ShipmentDetail.Sum (q => q.PickedQuantity))

                };
            }
        }
    }
}