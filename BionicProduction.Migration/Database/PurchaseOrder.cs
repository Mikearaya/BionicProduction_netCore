using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            Invoice = new HashSet<Invoice>();
            PurchaseOrderDetail = new HashSet<PurchaseOrderDetail>();
        }

        public uint Id { get; set; }
        public uint ClientId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint CreatedBy { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }

        public Customer Client { get; set; }
        public Employee CreatedByNavigation { get; set; }
        public ICollection<Invoice> Invoice { get; set; }
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
    }
}
