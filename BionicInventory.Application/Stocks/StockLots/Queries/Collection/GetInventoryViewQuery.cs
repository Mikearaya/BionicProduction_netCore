/*
 * @CreateTime: Jan 6, 2019 1:21 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 8:41 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Stocks.StockLots.Models;
using MediatR;

namespace BionicInventory.Application.Stocks.StockLots.Queries.Collection {
    public class GetInventoryViewQuery : IRequest<IEnumerable<InventoryView>> {

    }
}