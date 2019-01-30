/*
 * @CreateTime: Dec 30, 2018 8:11 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 8:44 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Stocks.StockLots.Models;
using MediatR;

namespace BionicInventory.Application.Stocks.StockLots.Queries.Collection {
    public class GetStockBatchDetailViewQuery : IRequest<StockBatchDetailView> {
        public uint Id { get; set; }
    }
}