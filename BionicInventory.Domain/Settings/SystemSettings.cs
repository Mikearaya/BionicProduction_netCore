/*
 * @CreateTime: Jan 6, 2019 12:50 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 6, 2019 12:50 AM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Domain.Settings {
    public class SystemSettings {
        public uint Id { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public sbyte? System { get; set; }
        public string Description { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}