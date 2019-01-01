/*
 * @CreateTime: Jan 1, 2019 8:38 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 1, 2019 9:15 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BionicProduction.Domain.WriteOffs;

namespace BionicInventory.Application.Inventory.WriteOffs.Models {
    public class WriteOffDetailView {

        public uint id { get; set; }
        public uint itemId { get; set; }
        public uint itemGroupId { get; set; }
        public string item { get; set; }
        public string itemGroup { get; set; }
        public string status { get; set; }
        public string note { get; set; }
        public string type { get; set; }
        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }
        public IEnumerable<WriteOffItemListView> WriteOffItems { get; set; }

        public static Expression<Func<WriteOff, WriteOffDetailView>> Projection {
            get {
                return writeoffs => new WriteOffDetailView () {
                    id = writeoffs.Id,
                    itemId = writeoffs.ItemId,
                    item = writeoffs.Item.Name,
                    itemGroup = writeoffs.Item.Group.GroupName,
                    itemGroupId = writeoffs.Item.GroupId,
                    status = writeoffs.Status,
                    type = writeoffs.Type,
                    note = writeoffs.Note,
                    dateAdded = writeoffs.DateAdded,
                    dateUpdated = writeoffs.DateUpdated,
                    WriteOffItems = writeoffs.WriteOffDetail.AsQueryable ().Select (WriteOffItemListView.Projection)
                };
            }
        }

    }
}