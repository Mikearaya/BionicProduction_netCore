/*
 * @CreateTime: Feb 18, 2019 11:18 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 18, 2019 11:18 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Procurments.PurchaseOrders.Models;
using MediatR;

namespace BionicInventory.Application.Procurments.PurchaseOrders.Queries.Collections {
    public class GetShippedPurchaseOrdersListQuery : IRequest<IEnumerable<PurchaseOrderListView>> {

    }
}