/*
 * @CreateTime: Feb 18, 2019 9:36 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 18, 2019 10:24 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.Items;

namespace BionicInventory.Domain.Procurment.PurchaseOrders {

    public partial class PurchaseOrderQuotation {
        public uint Id { get; set; }
        public uint PurchaseOrderId { get; set; }
        public float UnitPrice { get; set; }
        public float Quantity { get; set; }
        public DateTime ExpectedDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint ItemId { get; set; }

        public Item Item { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
    }
}