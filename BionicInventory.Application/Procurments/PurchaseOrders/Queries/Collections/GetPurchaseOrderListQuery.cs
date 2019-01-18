/*
 * @CreateTime: Jan 1, 2019 12:11 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 1, 2019 12:11 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Procurments.PurchaseOrders.Models;
using MediatR;

namespace BionicInventory.Application.Procurments.PurchaseOrders.Queries.Collections {
    public class GetPurchaseOrderListQuery : IRequest<IEnumerable<PurchaseOrderListView>> {

    }
}