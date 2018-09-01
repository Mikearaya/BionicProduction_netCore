using System.Collections.Generic;
using BionicInventory.Domain.Items.ItemPrices;

namespace BionicInventory.Application.Products.Models {
    public class ProductView {
        public uint id;
        public string code;
        public string name;
        public string discription;
        public float weight;
        public float unitCost;
        public string photo;
        public List<ItemPrice> Prices;

    }
}