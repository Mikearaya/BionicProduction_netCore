/*
 * @CreateTime: Oct 2, 2018 8:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 27, 2018 12:17 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Domain.Invoices.InvoiceDetails;
using BionicInventory.Domain.Invoices.InvoicePayment;
using BionicInventory.Domain.PurchaseOrders;

namespace BionicInventory.Domain.Invoices {
    public class Invoice {
        public Invoice () {
            InvoiceDetail = new HashSet<InvoiceDetail> ();
            InvoicePayments = new HashSet<InvoicePayments> ();
        }

        public uint Id { get; set; }
        public uint PurchaseOrderId { get; set; }
        public byte? PrintCount { get; set; } = 0;
        public string InvoiceType { get; set; }
        public float Tax {get; set;}
        public string Note {get; set;}
        public float Discount {get; set;}
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DueDate { get; set; }

        public PurchaseOrder PurchaseOrder { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetail { get; set; }
        public ICollection<InvoicePayments> InvoicePayments { get; set; }
    }
}