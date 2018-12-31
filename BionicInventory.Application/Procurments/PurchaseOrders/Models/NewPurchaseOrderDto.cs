/*
 * @CreateTime: Dec 31, 2018 11:36 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 1, 2019 12:08 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.Procurments.PurchaseOrders.Models {
    public class NewPurchaseOrderDto : IRequest<PurchaseOrderDetailView> {
        public NewPurchaseOrderDto () {
            PurchaseOrderItems = new List<PurchaseOrderItemDto> ();
        }

        public uint VendorId { get; set; }

        [Required]
        public string Status { get; set; }
        public DateTime ExpectedDate { get; set; }
        public DateTime? OrderedDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public float? Tax { get; set; }
        public float? AdditionalFee { get; set; }
        public float? Discount { get; set; }
        public string OrderId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string InvoiceId { get; set; }
        public DateTime? InvoiceDate { get; set; }

        IEnumerable<PurchaseOrderItemDto> PurchaseOrderItems { get; set; }

    }
}