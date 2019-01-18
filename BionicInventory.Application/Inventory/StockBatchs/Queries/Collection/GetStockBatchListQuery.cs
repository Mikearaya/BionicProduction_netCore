/*
 * @CreateTime: Dec 30, 2018 7:48 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 30, 2018 8:01 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Inventory.StockBatchs.Models;
using MediatR;

namespace BionicInventory.Application.Inventory.StockBatchs.Queries.Collection {
    public class GetStockBatchListQuery : IRequest<IEnumerable<StockBatchListView>> { }
}