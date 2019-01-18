/*
 * @CreateTime: Jan 4, 2019 8:20 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 10, 2019 8:15 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Inventory.StockBatchs.Models;
using MediatR;

namespace BionicInventory.Application.Inventory.StockBatchs.Queries.Collection {
    public class GetItemStockBatchsQuery : IRequest<IEnumerable<StockLotView>> {
        public uint ItemId { get; set; }
    }
}