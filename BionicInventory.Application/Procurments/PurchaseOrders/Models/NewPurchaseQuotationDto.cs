/*
 * @CreateTime: Feb 18, 2019 9:46 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 18, 2019 9:47 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.Procurments.PurchaseOrders.Models {
    public class NewPurchaseQuotationDto : IRequest<uint> {
        public NewPurchaseQuotationDto () {
            PurchaseOrderItems = new List<PurchaseOrderItemDto> ();
        }

        public uint VendorId { get; set; }

        [Required]
        public string Status { get; set; }
        public DateTime ExpectedDate { get; set; }
        public float? Tax { get; set; }
        public float? AdditionalFee { get; set; }
        public float? Discount { get; set; }

        public IEnumerable<PurchaseOrderItemDto> PurchaseOrderItems { get; set; }
    }
}