using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class BookedStockItems
    {
        public uint Id { get; set; }
        public uint StockId { get; set; }
        public sbyte? Canceled { get; set; }
        public uint BookedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint BookedFor { get; set; }
        public string Note { get; set; }

        public virtual Employee BookedByNavigation { get; set; }
        public virtual CustomerOrderItem BookedForNavigation { get; set; }
        public virtual FinishedProduct Stock { get; set; }
    }
}
