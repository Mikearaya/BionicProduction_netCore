/*
 * @CreateTime: Dec 4, 2018 11:09 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 4, 2018 11:21 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using BionicInventory.Domain.Items.BOMs;

namespace BionicInventory.Application.Products.BOMs.Queries.Models {
    public class BomItemView {
        public uint id { get; set; }
        public uint itemId { get; set; }
        public string item { get; set; }
        public string note { get; set; }
        public uint quantity { get; set; }
        public uint uomId { get; set; }
        public string uom { get; set; }
        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }

        public static Expression<Func<BomItems, BomItemView>> Projection {

            get {
                return bomItem => new BomItemView {
                    id = bomItem.Id,
                    itemId = bomItem.ItemId,
                    item = bomItem.Item.Name,
                    quantity = bomItem.Quantity,
                    uom = bomItem.Uom.Abrivation,
                    uomId = bomItem.UomId,
                    dateAdded = bomItem.DateAdded,
                    dateUpdated = bomItem.DateUpdated
                };
            }

        }

        public static BomItemView Create (BomItems bomItems) {
            return Projection.Compile ().Invoke (bomItems);
        }
    }
}