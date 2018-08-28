using System.Collections.Generic;
using BionicInventory.Application.Items.Interfaces;
using BionicInventory.Domain.Items;

namespace BionicInventory.Application.Items.Queries {
    public class ItemsQuery : IItemsQuery {
        public IEnumerable<Item> GetAll () {
            throw new System.NotImplementedException ();
        }

        public Item GetById (uint id) {
            throw new System.NotImplementedException ();
        }
    }
}