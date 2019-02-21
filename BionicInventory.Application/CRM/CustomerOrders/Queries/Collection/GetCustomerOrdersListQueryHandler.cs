/*
 * @CreateTime: Feb 21, 2019 10:12 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 21, 2019 10:14 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.CRM.CustomerOrders.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.CRM.CustomerOrders.Queries.Collection {
    public class GetCustomerOrdersListQueryHandler : IRequestHandler<GetCustomerOrdersListQuery, IEnumerable<CustomerOrderListView>> {
        private readonly IInventoryDatabaseService _database;

        public GetCustomerOrdersListQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<CustomerOrderListView>> Handle (GetCustomerOrdersListQuery request, CancellationToken cancellationToken) {
            return await _database.CustomerOrder
                .Select (CustomerOrderListView.Projection)
                .ToListAsync ();
        }
    }
}