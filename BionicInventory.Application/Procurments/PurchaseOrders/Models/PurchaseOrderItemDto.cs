/*
 * @CreateTime: Dec 31, 2018 11:39 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 31, 2018 11:40 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.Procurments.PurchaseOrders.Models {
    public class PurchaseOrderItemDto {
        public uint? Id { get; set; }
        public uint ItemId { get; set; }
        public float Quantity { get; set; }
        public float UnitPrice { get; set; }
        public DateTime? ExpectedDate { get; set; }
    }
}