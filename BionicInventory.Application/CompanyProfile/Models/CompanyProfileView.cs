/*
 * @CreateTime: Oct 16, 2018 11:29 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 16, 2018 11:30 PM
 * @Description: Modify Here, Please 
 */

using System;

namespace BionicInventory.Application.CompanyProfile.Models {
    public  class CompanyProfileView {
        public uint id { get; set; }
        public string name { get; set; }
        public string tin { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string subCity { get; set; }
        public string location { get; set; }
        public DateTime dateAdded { get; set; }
        public DateTime dateUpdated { get; set; }

    }
}