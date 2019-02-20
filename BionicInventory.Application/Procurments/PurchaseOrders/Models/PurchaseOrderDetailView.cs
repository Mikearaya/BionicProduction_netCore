/*
 * @CreateTime: Jan 1, 2019 12:03 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 18, 2019 10:35 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BionicInventory.Domain.Procurment.PurchaseOrders;

namespace BionicInventory.Application.Procurments.PurchaseOrders.Models {
    public class PurchaseOrderDetailView {

        private decimal _totalCost = 0;
        private float? _tax = 0;
        private float? _discount = 0;
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
        public float? tax {
            get {
                return _tax;
            }
            set {
                _tax = value == null ? 0 : value;
            }
        }
        public decimal totalCost {
            get {
                return (_totalCost - (_totalCost * (decimal) (tax / 100 + discount / 100))) + (decimal) additionalFee;
            }
            set {
                _totalCost = value;
            }
        }
        public float? additionalFee { get; set; }
        public float? discount {
            get {
                return _discount;
            }
            set {
                _discount = value == null ? 0 : value;
            }
        }
        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }
        public string orderId { get; set; }
        public DateTime? paymentDate { get; set; }
        public string invoiceId { get; set; }
        public DateTime? invoiceDate { get; set; }

        public DateTime? arivalDate { get; set; }

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
                    totalCost = (po.StockBatch.Count != 0) ?
                    (decimal) po.StockBatch.Sum (item => item.UnitCost * item.Quantity) : (
                    decimal) po.PurchaseOrderQuotation.Sum (item => item.UnitPrice * item.Quantity),
                    dateAdded = po.DateAdded,
                    dateUpdated = po.DateUpdated,
                    discount = po.Discount,
                    orderId = po.OrderId,
                    paymentDate = po.PaymentDate,
                    invoiceDate = po.InvoiceDate,
                    invoiceId = po.InvoiceId,
                    additionalFee = po.AdditionalFee,
                    OrderItems = (po.StockBatch.Count != 0) ?
                    po.StockBatch.AsQueryable ().Select (PurchaseOrderItemView.Projection) :
                    po.PurchaseOrderQuotation.AsQueryable ().Select (PurchaseOrderItemView.QuotProjection)

                };
            }
        }

        public static PurchaseOrderDetailView create (PurchaseOrder purchaseOrder) {
            return Projection.Compile ().Invoke (purchaseOrder);
        }
    }
}