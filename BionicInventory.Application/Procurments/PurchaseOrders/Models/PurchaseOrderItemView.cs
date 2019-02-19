/*
 * @CreateTime: Dec 31, 2018 11:55 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 19, 2019 9:41 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BionicInventory.Application.Stocks.StockLots.Models;
using BionicInventory.Domain.Procurment.PurchaseOrders;
using BionicProduction.Domain.StockBatchs;

namespace BionicInventory.Application.Procurments.PurchaseOrders.Models {
    public class PurchaseOrderItemView {

        public uint id { get; set; }
        public uint purchaseOrderId { get; set; }
        public uint itemId { get; set; }
        public IEnumerable<string> storageLocation { get; set; }
        public uint lotId { get; set; }
        public uint storageId { get; set; }
        public string item { get; set; }
        public uint itemGroupId { get; set; }
        public string itemGroup { get; set; }
        public float quantity { get; set; }
        public double subTotal { get; set; }
        public float unitPrice { get; set; }
        public DateTime expectedDate { get; set; }
        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }

        public static Expression<Func<StockBatch, PurchaseOrderItemView>> Projection {

            get {
                return po_item => new PurchaseOrderItemView () {
                    lotId = po_item.Id,
                    storageLocation = po_item.StockBatchStorage.AsQueryable ().Select (StockLotStorageView.StoragesProjection),
                    storageId = po_item.Item.DefaultStorageId,
                    purchaseOrderId = (uint) po_item.PurchaseOrderId,
                    itemId = po_item.ItemId,
                    item = po_item.Item.Name,
                    itemGroupId = po_item.Item.GroupId,
                    itemGroup = po_item.Item.Group.GroupName,
                    quantity = po_item.Quantity,
                    unitPrice = po_item.UnitCost,
                    subTotal = (double) po_item.Quantity * po_item.UnitCost,
                    expectedDate = po_item.AvailableFrom,
                    dateAdded = po_item.DateAdded,
                    dateUpdated = po_item.DateUpdated
                };
            }
        }

        public static Expression<Func<PurchaseOrderQuotation, PurchaseOrderItemView>> QuotProjection {

            get {
                return po_item => new PurchaseOrderItemView () {
                    id = po_item.Id,
                    purchaseOrderId = (uint) po_item.PurchaseOrderId,
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

        public static PurchaseOrderItemView Create (StockBatch po_item) {
            return Projection.Compile ().Invoke (po_item);
        }
    }
}