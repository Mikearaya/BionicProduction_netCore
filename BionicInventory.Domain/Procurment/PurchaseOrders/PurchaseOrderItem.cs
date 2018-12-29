/*
 * @CreateTime: Dec 29, 2018 9:40 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 29, 2018 9:41 PM
 * @Description: Modify Here, Please 
 */
using System;
using BionicInventory.Domain.Items;

namespace BionicInventory.Domain.Procurment.PurchaseOrders {
    public class PurchaseOrderItem {
        public uint Id { get; set; }
        public uint PurchaseOrderId { get; set; }
        public uint ItemId { get; set; }
        public float Quantity { get; set; }
        public float UnitPrice { get; set; }
        public DateTime ExpectedDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public Item Item { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
    }
}