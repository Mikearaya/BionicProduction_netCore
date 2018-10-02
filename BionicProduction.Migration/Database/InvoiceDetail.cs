using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class InvoiceDetail
    {
        public InvoiceDetail()
        {
            Sales = new HashSet<Sales>();
        }

        public uint Id { get; set; }
        public DateTime? DateAddded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint SalesOrderId { get; set; }
        public uint InvoiceNo { get; set; }
        public int Quantity { get; set; }

        public Invoice InvoiceNoNavigation { get; set; }
        public PurchaseOrderDetail SalesOrder { get; set; }
        public ICollection<Sales> Sales { get; set; }
    }
}
