/*
 * @CreateTime: Jan 4, 2019 11:06 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 4, 2019 11:15 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq;
using System.Linq.Expressions;
using BionicProduction.Domain.WriteOffs;

namespace BionicInventory.Application.Inventory.WriteOffs.Models {
    public class WriteOffListView {

        private float _quantity = 0;
        public uint id { get; set; }
        public uint itemId { get; set; }
        public uint itemGroupId { get; set; }
        public string item { get; set; }
        public string uom { get; set; }
        public string itemGroup { get; set; }
        public string status { get; set; }
        public float quantity { get; set; }

        public float totalCost { get; set; }
        public string note { get; set; }
        public string type { get; set; }
        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }

        private void calculateTotalCost () {

        }

        public static Expression<Func<WriteOff, WriteOffListView>> Projection {
            get {
                return writeoff => new WriteOffListView () {
                    id = writeoff.Id,
                    itemId = writeoff.ItemId,
                    item = writeoff.Item.Name,
                    itemGroup = writeoff.Item.Group.GroupName,
                    uom = writeoff.Item.PrimaryUom.Abrivation,
                    itemGroupId = writeoff.Item.GroupId,
                    status = writeoff.Status,
                    quantity = writeoff.WriteOffDetail.GroupBy (wd => wd.WriteOff).Sum (d => d.Sum (dq => dq.Quantity)),
                    totalCost = writeoff.WriteOffDetail.GroupBy (wd => wd.WriteOff).Sum (d => d.Sum (dq => dq.Quantity * dq.BatchStorage.Batch.UnitCost)),
                    type = writeoff.Type,
                    note = writeoff.Note,
                    dateAdded = writeoff.DateAdded,
                    dateUpdated = writeoff.DateUpdated,
                };
            }
        }

        public static WriteOffListView create (WriteOff writeoff) {
            return Projection.Compile ().Invoke (writeoff);
        }

    }
}