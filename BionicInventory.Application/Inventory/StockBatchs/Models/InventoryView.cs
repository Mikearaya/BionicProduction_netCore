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
        private float _quantity = 0;
        public uint itemId { get; set; }
        public string itemCode { get; set; }
        public string item { get; set; }
        public uint itemGroupId { get; set; }
        public string itemGroup { get; set; }
        public float quantity {
            get {
                return _quantity;
            }
            set {
                _quantity = value;
            }
        }
        public uint writeOffId { get; set; }
        public float totalCost { get; set; }
        public float averageUnitCost {
            get {
                return (quantity == 0) ? 0 : totalCost / quantity;
            }

        }

        public float totalWriteOffs { get; set; }
        public string uom { get; set; }

        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }

        public static Expression<Func<ItemBatchJoin, InventoryView>> Projection {

            get {
                return inventory => new InventoryView () {
                    itemId = inventory.Item.Id,
                    item = inventory.Item.Name,
                    itemCode = inventory.Item.Code,
                    uom = inventory.Item.PrimaryUom.Abrivation,
                    itemGroupId = inventory.Item.GroupId,
                    itemGroup = inventory.Item.Group.GroupName,
                    dateAdded = inventory.Item.DateAdded,
                    dateUpdated = inventory.Item.DateUpdate,
                    //   totalWriteOffs = inventory.Sum (d => d.StockBatchStorage.Sum (q => q.WriteOffDetail.Sum (w => w.Quantity))),

                    //  //   totalWriteOffs = inventory.totalWriteOffs,
                    //     quantity = inventory.Batch
                    //     .GroupBy (d => d.BatchId)
                    //     .Sum (item => item.Sum (storage => storage.Quantity - inventory.totalWriteOffs)),
                    //     totalCost = inventory.Batch
                    //     .GroupBy (d => d.BatchId)
                    //     .Sum (item => item.Sum (w => (w.Quantity - inventory.totalWriteOffs) * w.Batch.UnitCost)),

                };
            }
        }

    }
}