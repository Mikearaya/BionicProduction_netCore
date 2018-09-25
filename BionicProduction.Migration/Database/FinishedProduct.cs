using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class FinishedProduct
    {
        public FinishedProduct()
        {
            InvoiceDetail = new HashSet<InvoiceDetail>();
        }

        public uint Id { get; set; }
        public uint OrderId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint SubmittedBy { get; set; }
        public uint RecievedBy { get; set; }
        public int? Quantity { get; set; }

        public ProductionOrderList Order { get; set; }
        public Employee RecievedByNavigation { get; set; }
        public Employee SubmittedByNavigation { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetail { get; set; }
    }
}
