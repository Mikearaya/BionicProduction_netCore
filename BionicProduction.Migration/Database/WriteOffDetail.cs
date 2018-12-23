using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class WriteOffDetail
    {
        public uint Id { get; set; }
        public uint WriteOffId { get; set; }
        public float Quantity { get; set; }
        public uint BachStorageId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public StockBatchStorage BachStorage { get; set; }
        public WriteOff WriteOff { get; set; }
    }
}
