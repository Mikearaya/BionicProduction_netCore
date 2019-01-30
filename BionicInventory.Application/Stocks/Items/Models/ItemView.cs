/*
 * @CreateTime: Sep 9, 2018 6:14 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 7:45 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BionicInventory.Domain.Items;

namespace BionicInventory.Application.Stocks.Items.Models {
    public class ItemView {
        public uint id;
        public string code;
        public string name;
        public float? minimumQuantity;
        public string description;
        public float? weight;
        public float unitCost;
        public float? price;
        public string storingUoM;
        public string photo;

        public string defaultStorage { get; set; }
        public uint defaultStorageId { get; set; }

        public bool isInventoryItem { get; set; }
        public bool isProcured { get; set; }
        public uint primaryUomId { get; set; }
        public string primaryUom { get; set; }
        public uint? shelfLife { get; set; }
        public uint groupId { get; set; }
        public string group { get; set; }
        public DateTime? dateUpdated { get; set; }
        public DateTime? dateAdded { get; set; }

        public static Expression<Func<Item, ItemView>> Projection {

            get {
                return item => new ItemView () {
                    id = item.Id,
                    code = item.Code,
                    name = item.Name,
                    minimumQuantity = item.MinimumQuantity,
                    weight = item.Weight,
                    unitCost = item.UnitCost,
                    price = item.Price,
                    primaryUom = item.PrimaryUom.Abrivation,
                    primaryUomId = item.PrimaryUomId,
                    photo = item.Photo,
                    defaultStorage = item.StorageLocation.Name,
                    defaultStorageId = item.DefaultStorageId,
                    isInventoryItem = (item.IsInventory == 1) ? true : false,
                    isProcured = (item.IsProcured == 1) ? true : false,
                    shelfLife = item.ShelfLife,
                    groupId = item.GroupId,
                    group = item.Group.GroupName,
                    dateAdded = item.DateAdded,
                    dateUpdated = item.DateUpdate
                };
            }
        }
    }
}