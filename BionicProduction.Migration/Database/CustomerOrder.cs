using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class CustomerOrder
    {
        public CustomerOrder()
        {
            CustomerOrderItem = new HashSet<CustomerOrderItem>();
            Invoice = new HashSet<Invoice>();
        }

        public uint Id { get; set; }
        public uint ClientId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint CreatedBy { get; set; }
        public string Description { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? DueDate { get; set; }

        public Customer Client { get; set; }
        public Employee CreatedByNavigation { get; set; }
        public ICollection<CustomerOrderItem> CustomerOrderItem { get; set; }
        public ICollection<Invoice> Invoice { get; set; }
    }
}
