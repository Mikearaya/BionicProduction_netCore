/*
 * @CreateTime: Dec 31, 2018 11:55 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 1, 2019 12:02 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using BionicInventory.Domain.Procurment.PurchaseOrders;

namespace BionicInventory.Application.Procurments.PurchaseOrders.Models {
    public class PurchaseOrderItemView {

        public uint id { get; set; }
        public uint purchaseOrderId { get; set; }
        public uint itemId { get; set; }
        public string item { get; set; }
        public uint itemGroupId { get; set; }
        public string itemGroup { get; set; }
        public float quantity { get; set; }
        public double subTotal { get; set; }
        public float unitPrice { get; set; }
        public DateTime expectedDate { get; set; }
        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }

        public static Expression<Func<PurchaseOrderItem, PurchaseOrderItemView>> Projection {

            get {
                return po_item => new PurchaseOrderItemView () {
                    id = po_item.Id,
                    purchaseOrderId = po_item.PurchaseOrderId,
                    itemId = po_item.ItemId,
                    item = po_item.Item.Name,
                    itemGroupId = po_item.Item.GroupId,
                    itemGroup = po_item.Item.Group.GroupName,
                    quantity = po_item.Quantity,
                    unitPrice = po_item.UnitPrice,
                    subTotal = (double) po_item.Quantity * po_item.UnitPrice,
                    expectedDate = po_item.ExpectedDate,
                    dateAdded = po_item.DateAdded,
                    dateUpdated = po_item.DateUpdated
                };
            }
        }

        public static PurchaseOrderItemView Create (PurchaseOrderItem po_item) {
            return Projection.Compile ().Invoke (po_item);
        }
    }
}