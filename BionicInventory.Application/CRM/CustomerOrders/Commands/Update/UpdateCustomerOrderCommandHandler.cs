/*
 * @CreateTime: Feb 21, 2019 9:54 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 21, 2019 10:07 PM
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

namespace BionicInventory.Application.CRM.CustomerOrders.Commands.Update {
    public class UpdateCustomerOrderCommandHandler : IRequestHandler<UpdatedCustomerOrderDto, Unit> {
        private readonly IInventoryDatabaseService _database;

        public UpdateCustomerOrderCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (UpdatedCustomerOrderDto request, CancellationToken cancellationToken) {
            var customerOrder = await _database.CustomerOrder
                .FindAsync (request.Id);

            if (customerOrder == null) {
                throw new NotFoundException (nameof (CustomerOrder), request.Id);
            }

            customerOrder.OrderStatus = request.Status;
            customerOrder.Description = request.Description;
            customerOrder.DueDate = request.DeliveryDate;

            foreach (var item in customerOrder.CustomerOrderItem) {
                var updated = request.CustomerOrderItems.FirstOrDefault (c => c.Id == item.Id);
                if (updated == null) {
                    _database.CustomerOrderItem.Remove (item);
                    continue;
                }
                item.Quantity = updated.Quantity;
                item.DueDate = updated.DueDate;

            }

            _database.CustomerOrder.Update (customerOrder);

            await _database.SaveAsync ();

            return Unit.Value;

        }
    }
}