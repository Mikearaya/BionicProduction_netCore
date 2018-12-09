/*
 * @CreateTime: Sep 9, 2018 6:14 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 29, 2018 2:42 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;

namespace BionicInventory.Application.Products.Models {
    public class ProductView {
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
        public sbyte? isInventoryItem { get; set; }
        public sbyte? isProcured { get; set; }
        public uint primaryUomId { get; set; }
        public string primaryUom { get; set; }
        public uint? shelfLife { get; set; }
        public uint groupId { get; set; }
        public string group { get; set; }
        public DateTime? dateUpdated { get; set; }
        public DateTime? dateAdded { get; set; }
    }
}