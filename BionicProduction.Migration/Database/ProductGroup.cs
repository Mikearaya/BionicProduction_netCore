using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class ProductGroup
    {
        public ProductGroup()
        {
            InverseParentGroupNavigation = new HashSet<ProductGroup>();
            Item = new HashSet<Item>();
        }

        public uint Id { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public uint? ParentGroup { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public ProductGroup ParentGroupNavigation { get; set; }
        public ICollection<ProductGroup> InverseParentGroupNavigation { get; set; }
        public ICollection<Item> Item { get; set; }
    }
}
