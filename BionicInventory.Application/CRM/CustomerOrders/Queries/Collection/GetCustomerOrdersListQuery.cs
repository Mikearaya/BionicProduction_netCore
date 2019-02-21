/*
 * @CreateTime: Feb 21, 2019 10:11 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 21, 2019 10:12 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.CRM.CustomerOrders.Models;
using MediatR;

namespace BionicInventory.Application.CRM.CustomerOrders.Queries.Collection {
    public class GetCustomerOrdersListQuery : IRequest<IEnumerable<CustomerOrderListView>> {

    }
}