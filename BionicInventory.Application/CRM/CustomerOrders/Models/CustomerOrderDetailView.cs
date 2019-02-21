/*
 * @CreateTime: Feb 21, 2019 9:11 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 21, 2019 9:34 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BionicInventory.Domain.CustomerOrders;

namespace BionicInventory.Application.CRM.CustomerOrders.Models {
    public class CustomerOrderDetailView {

        public uint Id { get; set; }
        public uint CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public string CreatedBy { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public double Discount { get; set; }
        public IEnumerable<CustomerOrderItemView> CustomerOrderItems = new List<CustomerOrderItemView> ();

        public static Expression<Func<CustomerOrder, CustomerOrderDetailView>> Projection {
            get {
                return order => new CustomerOrderDetailView () {
                    Id = order.Id,
                    CustomerId = order.ClientId,
                    CustomerName = order.Client.FullName,
                    Status = order.OrderStatus,
                    DeliveryDate = order.DueDate,
                    DateAdded = order.DateAdded,
                    DateUpdated = order.DateUpdated,
                    Description = order.Description,
                    CustomerOrderItems = order.CustomerOrderItem.AsQueryable ().Select (CustomerOrderItemView.Projection)

                };
            }
        }
    }
}