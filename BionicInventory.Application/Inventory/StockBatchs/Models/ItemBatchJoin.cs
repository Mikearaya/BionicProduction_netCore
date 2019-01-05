/*
 * @CreateTime: Jan 6, 2019 1:47 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 6, 2019 1:49 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Domain.Items;
using BionicProduction.Domain.StockBatchs;

namespace BionicInventory.Application.Inventory.StockBatchs.Models {
    public class ItemBatchJoin {
        public Item Item { get; set; }
        public StockBatch Batch { get; set; }
    }
}