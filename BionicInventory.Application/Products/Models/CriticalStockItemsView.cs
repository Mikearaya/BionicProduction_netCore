/*
 * @CreateTime: Oct 21, 2018 1:00 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 29, 2018 2:41 PM
 * @Description: Modify Here, Please 
 */

namespace BionicInventory.Application.Products.Models {

    public class CriticalStockItemsView {
        public uint id { get; set; }
        public string description { get; set; }
        public string productName { get; set; }
        public string productCode { get; set; }

        public float required { get; set; }
        public float? minimumQuantity { get; set; }

        public float availableQuantity { get; set; }
        public float expectedAvailableQuantity { get; set; }

        public string storingUoM { get; set; }

        public float inStock { get; set; }

    }
}