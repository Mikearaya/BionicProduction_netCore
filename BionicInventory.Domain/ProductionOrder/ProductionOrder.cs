using System;
using System.Collections.Generic;
using BionicInventory.Domain.ProductionOrders.ProductionOrderLists;

namespace BionicInventory.Domain.ProductionOrders
{
    public class ProductionOrder
    {
        public ProductionOrder()
        {
            ProductionOrderList = new HashSet<ProductionOrderList>();
        }

        public uint Id { get; set; }
        public DateTime? OrderedOn { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public ICollection<ProductionOrderList> ProductionOrderList { get; set; }
    }
}
