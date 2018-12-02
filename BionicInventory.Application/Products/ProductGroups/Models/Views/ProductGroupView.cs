/*
 * @CreateTime: Dec 2, 2018 1:05 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 2, 2018 1:21 AM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.Products.ProductGroups.Models.Views {
    public class ProductGroupView {

        public uint id { get; set; }
        public string groupName { get; set; }
        public string description { get; set; }
        public uint? parentGroupId { get; set; }
        public string parentGroup { get; set; }
        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }

    }
}