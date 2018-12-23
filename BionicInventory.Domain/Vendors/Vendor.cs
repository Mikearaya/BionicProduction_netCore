/*
 * @CreateTime: Dec 23, 2018 9:41 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 23, 2018 9:41 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;

namespace BionicInventory.Domain.Vendors {
    public class Vendor {
        public Vendor () {
            VendorPurchaseTerm = new HashSet<VendorPurchaseTerm> ();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string TinNumber { get; set; }
        public uint? LeadTime { get; set; }
        public uint? PaymentPeriod { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public ICollection<VendorPurchaseTerm> VendorPurchaseTerm { get; set; }
    }
}