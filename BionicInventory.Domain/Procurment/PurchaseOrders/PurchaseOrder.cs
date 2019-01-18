/*
 * @CreateTime: Dec 29, 2018 9:40 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 29, 2018 9:43 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.Procurment.Vendors;

namespace BionicInventory.Domain.Procurment.PurchaseOrders {
    public class PurchaseOrder {
        public PurchaseOrder () {
            PurchaseOrderItem = new HashSet<PurchaseOrderItem> ();
        }

        public uint Id { get; set; }
        public uint VendorId { get; set; }
        public string Status { get; set; }
        public DateTime ExpectedDate { get; set; }
        public DateTime? OrderedDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public float? Tax { get; set; }
        public float? AdditionalFee { get; set; }
        public float? Discount { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string OrderId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string InvoiceId { get; set; }
        public DateTime? InvoiceDate { get; set; }

        public Vendor Vendor { get; set; }
        public ICollection<PurchaseOrderItem> PurchaseOrderItem { get; set; }

    }
}