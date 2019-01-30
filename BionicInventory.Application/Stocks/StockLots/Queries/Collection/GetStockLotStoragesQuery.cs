/*
 * @CreateTime: Jan 10, 2019 8:07 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 8:43 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Stocks.StockLots.Models;
using MediatR;

namespace BionicInventory.Application.Stocks.StockLots.Queries.Collection {
    public class GetStockLotStoragesQuery : IRequest<IEnumerable<StockLotStorageView>> {
        public uint LotId { get; set; }
    }
}