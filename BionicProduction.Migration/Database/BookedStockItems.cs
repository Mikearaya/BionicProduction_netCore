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

        public Employee BookedByNavigation { get; set; }
        public PurchaseOrderDetail BookedForNavigation { get; set; }
        public FinishedProduct Stock { get; set; }
    }
}
