/*
 * @CreateTime: Feb 21, 2019 10:07 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 21, 2019 10:10 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.CRM.CustomerOrders.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.CustomerOrders;
using MediatR;

namespace BionicInventory.Application.CRM.CustomerOrders.Commands {
    public class DeleteCustomerOrderCommandHandler : IRequestHandler<DeletedCustomerOrderDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public DeleteCustomerOrderCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeletedCustomerOrderDto request, CancellationToken cancellationToken) {
            var customerOrder = await _database.CustomerOrder.FindAsync (request.Id);

            if (customerOrder == null) {
                throw new NotFoundException (nameof (CustomerOrder), request.Id);
            }

            _database.CustomerOrder.Remove (customerOrder);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}