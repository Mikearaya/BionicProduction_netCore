/*
 * @CreateTime: Jan 30, 2019 8:28 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 8:28 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Products.Models;
using MediatR;

namespace BionicInventory.Application.Stocks.Items.Queries.Collections {
    public class GetCriticalItemsListQuery : IRequest<IEnumerable<CriticalItemsView>> {

    }
}