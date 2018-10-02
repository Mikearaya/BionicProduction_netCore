using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class Sales
    {
        public uint Id { get; set; }
        public uint InvoiceId { get; set; }
        public uint StockId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint StoreKeeper { get; set; }

        public InvoiceDetail Invoice { get; set; }
        public FinishedProduct Stock { get; set; }
        public Employee StoreKeeperNavigation { get; set; }
    }
}
