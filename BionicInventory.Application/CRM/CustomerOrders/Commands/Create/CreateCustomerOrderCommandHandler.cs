/*
 * @CreateTime: Feb 21, 2019 9:35 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 21, 2019 9:53 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.CRM.CustomerOrders.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Domain.CustomerOrders;
using BionicInventory.Domain.Customers;
using BionicInventory.Domain.Items;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.CRM.CustomerOrders.Commands.Create {
    public class CreateCustomerOrderCommandHandler : IRequestHandler<NewCustomerOrderDto, uint> {
        private readonly IInventoryDatabaseService _database;

        public CreateCustomerOrderCommandHandler (IInventoryDatabaseService database) {
            _database = database;
        }

        public async Task<uint> Handle (NewCustomerOrderDto request, CancellationToken cancellationToken) {
            var customer = await _database.Customer
                .AsNoTracking ()
                .FirstOrDefaultAsync (c => c.Id == request.ClientId);

            if (customer == null) {
                throw new NotFoundException (nameof (Customer), request.ClientId);
            }

            CustomerOrder newOrder = new CustomerOrder () {
                ClientId = request.ClientId,
                OrderStatus = request.Status,
                Description = request.Description,
                DueDate = request.DeliveryDate,
            };
            foreach (var item in request.CustomerOrderDetail) {

                var currentItem = await _database.Item
                    .AsNoTracking ()
                    .FirstOrDefaultAsync (i => i.Id == item.ItemId);

                if (currentItem == null) {
                    throw new NotFoundException (nameof (Item), item.ItemId);
                }

                newOrder.CustomerOrderItem.Add (new CustomerOrderItem () {
                    ItemId = item.ItemId,
                        Quantity = item.Quantity,
                        PricePerItem = item.UnitPrice,
                        DueDate = item.DueDate
                });
            }

            _database.CustomerOrder.Add (newOrder);
            await _database.SaveAsync ();

            return newOrder.Id;

        }
    }
}