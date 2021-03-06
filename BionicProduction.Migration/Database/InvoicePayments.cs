﻿using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class InvoicePayments
    {
        public uint Id { get; set; }
        public uint InvoiceNo { get; set; }
        public float Amount { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint CashierId { get; set; }
        public int? PrintCount { get; set; }
        public string Note { get; set; }

        public virtual Employee Cashier { get; set; }
        public virtual Invoice InvoiceNoNavigation { get; set; }
    }
}
