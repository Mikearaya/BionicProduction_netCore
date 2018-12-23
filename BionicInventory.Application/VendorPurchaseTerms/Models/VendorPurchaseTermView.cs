/*
 * @CreateTime: Dec 24, 2018 12:15 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 24, 2018 12:28 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using BionicInventory.Domain.Vendors;

namespace BionicInventory.Application.Vendors.PurchaseTerms.Models {
    public class VendorPurchaseTermView {
        public uint id { get; set; }
        public uint vendorId { get; set; }
        public uint itemId { get; set; }
        public string vendorProductId { get; set; }
        public uint? priority { get; set; }
        public uint? leadtime { get; set; }
        public float? minimumQuantity { get; set; }
        public float unitPrice { get; set; }
        public string item { get; set; }
        public string vendor { get; set; }
        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }

        public static Expression<Func<VendorPurchaseTerm, VendorPurchaseTermView>> Projection {
            get {
                return term => new VendorPurchaseTermView () {
                    id = term.Id,
                    vendor = term.Vendor.Name,
                    item = term.Item.Name,
                    vendorProductId = term.VendorProductId,
                    priority = term.Priority,
                    leadtime = (term.Leadtime == 0) ? term.Vendor.LeadTime : 0,
                    minimumQuantity = term.MinimumQuantity,
                    unitPrice = term.UnitPrice,
                    itemId = term.ItemId,
                    vendorId = term.VendorId,
                    dateAdded = term.DateAdded,
                    dateUpdated = term.DateUpdated
                };
            }
        }

        public static VendorPurchaseTermView Create (VendorPurchaseTerm purchaseTerm) {
            return Projection.Compile ().Invoke (purchaseTerm);
        }

    }
}