/*
 * @CreateTime: Feb 21, 2019 8:49 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 21, 2019 9:11 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq;
using System.Linq.Expressions;
using BionicInventory.Domain.CustomerOrders;

namespace BionicInventory.Application.CRM.CustomerOrders.Models {
    public class CustomerOrderListView {
        public uint Id { get; set; }
        public double TotalQuantity { get; set; }
        public uint CustomerId { get; set; }
        public string CustomerName { get; set; }
        public double? TotalPrice { get; set; }

        public double? TotalCost { get; set; }
        public double? Profit {
            get {
                return TotalPrice - TotalCost;
            }
        }
        public string Status { get; set; }

        public string ProductStatus { get; set; }
        public string InvoiceStatus { get; set; }
        public string PaymentStatus { get; set; }
        public uint? totalShipped { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public static Expression<Func<CustomerOrder, CustomerOrderListView>> Projection {
            get {
                return order => new CustomerOrderListView () {
                    Id = order.Id,
                    CustomerId = order.ClientId,
                    CustomerName = order.Client.FullName,
                    Status = order.OrderStatus,
                    TotalCost = order.CustomerOrderItem.AsQueryable ()
                    .Sum (o => o.BookedStockBatch
                    .Sum (s => s.BatchStorage.Batch.UnitCost * o.Quantity)),
                    TotalPrice = order.CustomerOrderItem.Sum (o => o.PricePerItem * o.Quantity),
                    TotalQuantity = order.CustomerOrderItem.Sum (o => o.Quantity),
                    DeliveryDate = order.DueDate,
                    DateAdded = order.DateAdded,
                    DateUpdated = order.DateUpdated
                };
            }
        }
    }
}