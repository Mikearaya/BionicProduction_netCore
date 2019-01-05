/*
 * @CreateTime: Jan 6, 2019 12:58 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 6, 2019 2:01 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq;
using System.Linq.Expressions;
using BionicInventory.Domain.Items;
using BionicProduction.Domain.StockBatchs;

namespace BionicInventory.Application.Inventory.StockBatchs.Models {
    public class InventoryView {

        public uint itemId { get; set; }
        public string itemCode { get; set; }
        public string item { get; set; }
        public uint itemGroupId { get; set; }
        public string itemGroup { get; set; }
        public float quantity { get; set; }
        public float totalCost { get; set; }
        public float averageUnitCost {
            get {
                return (quantity == 0) ? 0 : totalCost / quantity;
            }

        }
        public string uom { get; set; }

        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }

        public static Expression<Func<Item, InventoryView>> Projection {

            get {
                return inventory => new InventoryView () {
                    itemId = inventory.Id,
                    item = inventory.Name,
                    itemCode = inventory.Code,
                    uom = inventory.PrimaryUom.Abrivation,
                    itemGroupId = inventory.GroupId,
                    itemGroup = inventory.Group.GroupName,
                    dateAdded = inventory.DateAdded,
                    dateUpdated = inventory.DateUpdate,

                    quantity = inventory.StockBatch.GroupBy (s => s.Item).Sum (i => i.Sum (b => b.Quantity)),
                    totalCost = inventory.StockBatch.GroupBy (s => s.Item).Sum (i => i.Sum (b => b.Quantity)),
                };
            }
        }

    }
}