﻿using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class ItemPrice
    {
        public uint Id { get; set; }
        public uint ItemId { get; set; }
        public float Price { get; set; }
        public string CategoryName { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string Currency { get; set; }

        public Item Item { get; set; }
    }
}