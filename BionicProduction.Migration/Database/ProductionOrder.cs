using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class ProductionOrder
    {
        public ProductionOrder()
        {
            ProductionOrderList = new HashSet<ProductionOrderList>();
        }

        public uint Id { get; set; }
        public uint OrderedBy { get; set; }
        public string Description { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public Employee OrderedByNavigation { get; set; }
        public ICollection<ProductionOrderList> ProductionOrderList { get; set; }
    }
}
