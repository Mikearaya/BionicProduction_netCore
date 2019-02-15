/*
 * @CreateTime: Jan 30, 2019 7:59 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 7, 2019 11:10 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Domain.Items;
using BionicProduction.Domain.StockBatchs;

namespace BionicInventory.Application.Stocks.Items.Models {
    public class ItemLotJoin {
        public Item Item { get; set; }
        public string uom { get; set; }
        public uint uomId { get; set; }

        public string group { get; set; }
        public uint groupId { get; set; }
        public IEnumerable<StockBatchStorage> Lot { get; set; } = new List<StockBatchStorage> ();
    }
}