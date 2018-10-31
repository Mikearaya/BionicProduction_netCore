/*
 * @CreateTime: Sep 9, 2018 6:14 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 9, 2018 6:43 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Domain.Items.ItemPrices;

namespace BionicInventory.Application.Products.Models {
    public class ProductView {
        public uint id;
        public string code;
        public string name;
        public float minimumQuantity;
        public string description;
        public float weight;
        public float unitCost;
        public string unit;
        public string photo;

    }
}