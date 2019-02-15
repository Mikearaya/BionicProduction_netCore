using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class FinishedProduct
    {
        public uint Id { get; set; }
        public uint OrderId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint SubmittedBy { get; set; }
        public uint RecievedBy { get; set; }
        public int? Quantity { get; set; }

        public virtual ProductionOrderList Order { get; set; }
        public virtual Employee RecievedByNavigation { get; set; }
        public virtual Employee SubmittedByNavigation { get; set; }
        public virtual BookedStockItems BookedStockItems { get; set; }
    }
}
