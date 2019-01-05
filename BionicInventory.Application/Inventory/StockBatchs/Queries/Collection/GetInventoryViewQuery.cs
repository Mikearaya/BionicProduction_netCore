/*
 * @CreateTime: Jan 6, 2019 1:21 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 6, 2019 1:21 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Inventory.StockBatchs.Models;
using MediatR;

namespace BionicInventory.Application.Inventory.StockBatchs.Queries.Collection {
    public class GetInventoryViewQuery : IRequest<IEnumerable<InventoryView>> {

    }
}