/*
 * @CreateTime: Jan 30, 2019 7:49 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 7:49 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Stocks.Items.Models;
using MediatR;

namespace BionicInventory.Application.Stocks.Items.Queries.Collections {
    public class GetItemsLIstQuery : IRequest<IEnumerable<ItemView>> {

    }
}