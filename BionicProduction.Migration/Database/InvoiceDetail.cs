using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class InvoiceDetail
    {
        public uint Id { get; set; }
        public DateTime? DateAddded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint SalesOrderId { get; set; }
        public uint InvoiceNo { get; set; }
        public int Quantity { get; set; }
        public float? Discount { get; set; }
        public string Note { get; set; }
        public float UnitPrice { get; set; }
        public float? Tax { get; set; }

        public Invoice InvoiceNoNavigation { get; set; }
        public CustomerOrderItem SalesOrder { get; set; }
    }
}
