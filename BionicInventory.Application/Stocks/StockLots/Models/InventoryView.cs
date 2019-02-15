/*
 * @CreateTime: Jan 6, 2019 12:58 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 7, 2019 11:13 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq;
using System.Linq.Expressions;
using BionicInventory.Application.Stocks.Items.Models;
using BionicInventory.Domain.Items;
using BionicProduction.Domain.StockBatchs;

namespace BionicInventory.Application.Stocks.StockLots.Models {
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
        public uint uomId { get; set; }
        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }

        public static Expression<Func<IGrouping<Item, ItemLotJoin>, InventoryView>> Projection {

            get {
                return inventory => new InventoryView () {
                    itemId = inventory.Key.Id,
                    item = inventory.Key.Name,
                    itemCode = inventory.Key.Code,
                    uom = inventory.Select (i => i.uom).FirstOrDefault (),
                    uomId = inventory.Key.PrimaryUomId,
                    itemGroupId = inventory.Key.GroupId,
                    itemGroup = inventory.Select (i => i.group).FirstOrDefault (),
                    dateAdded = inventory.Key.DateAdded,
                    dateUpdated = inventory.Key.DateUpdate,
                    quantity = inventory.Sum (s => s.Lot.Where (stat => stat.Batch.Status.ToUpper () == "RECIEVED").Sum (q => q.Quantity)),
                    totalCost = inventory.Sum (s => s.Lot.Where (stat => stat.Batch.Status.ToUpper () == "RECIEVED").Sum (q => q.Quantity * q.Batch.UnitCost))

                };
            }
        }

    }
}