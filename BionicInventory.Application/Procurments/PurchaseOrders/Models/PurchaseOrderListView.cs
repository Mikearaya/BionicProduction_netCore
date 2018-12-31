/*
 * @CreateTime: Dec 31, 2018 11:45 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 31, 2018 11:54 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq;
using System.Linq.Expressions;
using BionicInventory.Domain.Procurment.PurchaseOrders;

namespace BionicInventory.Application.Procurments.PurchaseOrders.Models {
    public class PurchaseOrderListView {

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

        public static Expression<Func<PurchaseOrder, PurchaseOrderListView>> Projection {

            get {
                return po => new PurchaseOrderListView () {
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
                    additionalFee = po.AdditionalFee
                };
            }
        }

        public static PurchaseOrderListView Create (PurchaseOrder purchaseOrder) {
            return Projection.Compile ().Invoke (purchaseOrder);
        }
    }
}