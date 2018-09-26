using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            PurchaseOrderDetail = new HashSet<PurchaseOrderDetail>();
        }

        public uint Id { get; set; }
        public uint ClientId { get; set; }
        public DateTime IssuedOn { get; set; }
        public DateTime DueDate { get; set; }
        public float InitialPayment { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint CreatedBy { get; set; }

        public Customer Client { get; set; }
        public Employee CreatedByNavigation { get; set; }
        public Invoice Invoice { get; set; }
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
    }
}
