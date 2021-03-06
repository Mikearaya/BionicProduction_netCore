/*
 * @CreateTime: Jan 6, 2019 1:47 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 8:37 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Domain.Items;
using BionicProduction.Domain.StockBatchs;
using BionicProduction.Domain.WriteOffs;

namespace BionicInventory.Application.Stocks.StockLots.Models {
    public class ItemBatchJoin {
        public Item Item { get; set; }
        public StockBatch StockLots { get; set; }
        public float? lotQuantity { get; set; }

        public float? totalWriteOff { get; set; }
        public WriteOff WriteOffs { get; set; }
    }
}