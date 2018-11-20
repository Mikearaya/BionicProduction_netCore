using System;
using System.Collections.Generic;
using BionicInventory.Domain.Customers;

namespace BionicInventory.Application.Invoices.Models.ViewModels {
    public class InvoiceDetailView {
        public uint Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string invoiceType {get; set;}

        public DateTime? DeliveryDate { get; set; }

        public uint CustomerId { get; set; }

        public string customerName { get; set; }

        public string country { get; set; }
        public string city { get; set; }
        public string subCity { get; set; }
        public string phoneNumber { get; set; }
        public string emailAddress { get; set; }
        public string poNo { get; set; }

        public uint preparedById { get; set; }
        public string preparedBy { get; set; }
        public string paymentMethod {get; set;}
        public double? total { get; set; }
        public float? tax { get; set; }
        public double? taxedTotal { get; set; }
        public uint customerOrderId { get; set; }
        public double? discount { get; set; }
        public string note { get; set; }

        public Object customer { get; set; }


        public IEnumerable<InvoiceItems> invoiceItems { get; set; }

    }
}