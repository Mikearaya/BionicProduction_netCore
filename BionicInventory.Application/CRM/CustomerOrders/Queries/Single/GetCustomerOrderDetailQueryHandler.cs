/*
 * @CreateTime: Feb 21, 2019 10:15 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 21, 2019 10:19 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.CRM.CustomerOrders.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.CustomerOrders;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.CRM.CustomerOrders.Queries.Single {
    public class GetCustomerOrderDetailQueryHandler : IRequestHandler<GetCustomerOrderDetailQuery, CustomerOrderDetailView> {
        private readonly IInventoryDatabaseService _database;

        public GetCustomerOrderDetailQueryHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<CustomerOrderDetailView> Handle (GetCustomerOrderDetailQuery request, CancellationToken cancellationToken) {
            var customerOrder = await _database.CustomerOrder
                .Where (o => o.Id == request.Id)
                .Select (CustomerOrderDetailView.Projection)
                .FirstOrDefaultAsync ();

            if (customerOrder == null) {
                throw new NotFoundException (nameof (CustomerOrder), request.Id);
            }

            return customerOrder;
        }
    }
}