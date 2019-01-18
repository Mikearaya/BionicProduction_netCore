/*
 * @CreateTime: Dec 23, 2018 9:41 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 15, 2019 12:38 AM
 * @Description: Modify Here, Please 
 */
using System;
using BionicInventory.Domain.Items;

namespace BionicInventory.Domain.Procurment.Vendors {
    public class VendorPurchaseTerm {
        public uint Id { get; set; }
        public uint VendorId { get; set; }
        public uint ItemId { get; set; }
        public string VendorProductId { get; set; }
        public uint? Priority { get; set; }
        public uint? Leadtime { get; set; }
        public uint? MinimumQuantity { get; set; }
        public float UnitPrice { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public Item Item { get; set; }
        public Vendor Vendor { get; set; }
    }
}