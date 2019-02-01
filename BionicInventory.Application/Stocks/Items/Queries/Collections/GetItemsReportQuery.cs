/*
 * @CreateTime: Jan 31, 2019 6:36 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 31, 2019 6:38 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Stocks.Items.Models;
using MediatR;

namespace BionicInventory.Application.Stocks.Items.Queries.Collections {
    public class GetItemsReportQuery : IRequest<IEnumerable<ItemReportListView>> {

    }
}