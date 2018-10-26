

using System;
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.Invoices.Models {

    public abstract class InvoiceItemDto {
        [Required]
        public uint CustomerOrderItemId {get; set;}
        [Required]
        public uint Quantity {get; set;}
        [Required]
        public  uint UnitPrice {get; set;}
        public float Discount {get; set;}  = 0;
        public float Tax {get; set;}  = 0;
        public string Note {get; set;}
    }

}