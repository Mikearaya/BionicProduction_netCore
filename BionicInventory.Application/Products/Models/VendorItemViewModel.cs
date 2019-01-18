/*
 * @CreateTime: Jan 15, 2019 12:07 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 15, 2019 12:46 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using BionicInventory.Domain.Procurment.Vendors;

namespace BionicInventory.Application.Products.Models {
    public class VendorItemViewModel {
        public uint id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public uint? minimumQuantity { get; set; }
        public float? price { get; set; }
        public string vendorItemCode { get; set; }
        public uint? priority { get; set; }
        public string photo { get; set; }
        public uint primaryUomId { get; set; }
        public string primaryUom { get; set; }
        public uint groupId { get; set; }
        public uint? leadTime { get; set; }
        public string group { get; set; }
        public DateTime? dateUpdated { get; set; }
        public DateTime? dateAdded { get; set; }

        public static Expression<Func<VendorPurchaseTerm, VendorItemViewModel>> Projection {

            get {
                return term => new VendorItemViewModel () {
                    id = term.ItemId,
                    name = term.Item.Name,
                    code = term.Item.Code,
                    vendorItemCode = term.VendorProductId,
                    minimumQuantity = term.MinimumQuantity,
                    price = term.UnitPrice,
                    leadTime = term.Leadtime,
                    groupId = term.Item.GroupId,
                    group = term.Item.Group.GroupName,
                    primaryUom = term.Item.PrimaryUom.Abrivation,
                    primaryUomId = term.Item.PrimaryUomId,
                    photo = term.Item.Photo,
                    priority = term.Priority,
                    dateAdded = term.Item.DateAdded,
                    dateUpdated = term.Item.DateUpdate
                };
            }
        }

    }
}