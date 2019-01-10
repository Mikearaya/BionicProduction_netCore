/*
 * @CreateTime: Jan 10, 2019 8:07 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 10, 2019 8:07 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Inventory.StockBatchs.Models;
using MediatR;

namespace BionicInventory.Application.Inventory.StockBatchs.Queries.Collection {
    public class GetStockLotStoragesQuery : IRequest<IEnumerable<StockLotStorageView>> {
        public uint LotId { get; set; }
    }
}