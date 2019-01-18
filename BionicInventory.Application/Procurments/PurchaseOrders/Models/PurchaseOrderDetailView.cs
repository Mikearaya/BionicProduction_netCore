/*
 * @CreateTime: Jan 1, 2019 12:03 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 1, 2019 12:08 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BionicInventory.Domain.Procurment.PurchaseOrders;

namespace BionicInventory.Application.Procurments.PurchaseOrders.Models {
    public class PurchaseOrderDetailView {
        public PurchaseOrderDetailView () {
            OrderItems = new List<PurchaseOrderItemView> ();
        }

        public uint id { get; set; }
        public uint vendorId { get; set; }
        public string vendor { get; set; }
        public string status { get; set; }
        public DateTime expectedDate { get; set; }
        public DateTime? orderedDate { get; set; }
        public DateTime? shippedDate { get; set; }
        public float? tax { get; set; }
        public float totalCost { get; set; }
        public float? additionalFee { get; set; }
        public float? discount { get; set; }
        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }
        public string orderId { get; set; }
        public DateTime? paymentDate { get; set; }
        public string invoiceId { get; set; }
        public DateTime? invoiceDate { get; set; }

        public IEnumerable<PurchaseOrderItemView> OrderItems { get; set; }

        public static Expression<Func<PurchaseOrder, PurchaseOrderDetailView>> Projection {
            get {
                return po => new PurchaseOrderDetailView () {
                    id = po.Id,
                    vendor = po.Vendor.Name,
                    vendorId = po.VendorId,
                    status = po.Status,
                    expectedDate = po.ExpectedDate,
                    orderedDate = po.OrderedDate,
                    shippedDate = po.ShippedDate,
                    tax = po.Tax,
                    totalCost = po.PurchaseOrderItem.Sum (item => item.UnitPrice * item.Quantity) + (float) po.AdditionalFee,
                    dateAdded = po.DateAdded,
                    dateUpdated = po.DateUpdated,
                    discount = po.Discount,
                    orderId = po.OrderId,
                    paymentDate = po.PaymentDate,
                    invoiceDate = po.InvoiceDate,
                    invoiceId = po.InvoiceId,
                    additionalFee = po.AdditionalFee,
                    OrderItems = po.PurchaseOrderItem.AsQueryable ().Select (PurchaseOrderItemView.Projection)

                };
            }
        }

        public static PurchaseOrderDetailView create (PurchaseOrder purchaseOrder) {
            return Projection.Compile ().Invoke (purchaseOrder);
        }
    }
}