/*
 * @CreateTime: Feb 21, 2019 11:01 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 21, 2019 11:18 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using BionicInventory.Application.CRM.CustomerOrders.Models;
using BionicInventory.Application.CRM.CustomerOrders.Queries.Collection;
using BionicInventory.Application.CRM.CustomerOrders.Queries.Single;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.CRM.CustomerOrders {
    [InventoryAPI ("crm/customer-orders")]
    public class CustomerOrdersController : Controller {
        private readonly IMediator _Mediator;

        public CustomerOrdersController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpGet ("{id}")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<CustomerOrderDetailView>> GetCustomerOrderById (uint id) {

            try {

                if (id == 0) {
                    return StatusCode (400);
                }

                var customerOrder = await _Mediator.Send (new GetCustomerOrderDetailQuery () { Id = id });

                return StatusCode (200, customerOrder);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<CustomerOrderListView>>> GetCustomerOrdersList () {

            var customerOrder = await _Mediator.Send (new GetCustomerOrdersListQuery ());

            return StatusCode (200, customerOrder);

        }

        [HttpPost]
        [ProducesResponseType (201)]
        [ProducesResponseType (400)]
        [ProducesResponseType (422)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<CustomerOrderDetailView>> CreateCustomerOrder ([FromBody] NewCustomerOrderDto customerOrder) {

            try {

                if (customerOrder == null) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                var result = await _Mediator.Send (customerOrder);

                var newCustomerOrder = await _Mediator.Send (new GetCustomerOrderDetailQuery () { Id = result });

                return StatusCode (201, newCustomerOrder);

            } catch (NotFoundException e) {

                return StatusCode (404, e.Message);

            }

        }

        [HttpPut ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (422)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<CustomerOrderDetailView>> UpdateCustomerOrder (uint id, [FromBody] UpdatedCustomerOrderDto updatedCustomerOrder) {

            try {

                if (updatedCustomerOrder == null || id != updatedCustomerOrder.Id) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                var result = await _Mediator.Send (updatedCustomerOrder);

                return StatusCode (204);

            } catch (NotFoundException e) {

                return StatusCode (404, e.Message);

            }

        }

        [HttpDelete ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<CustomerOrderDetailView>> DeleteCustomerOrder (uint id) {

            try {

                if (id == 0) {
                    return StatusCode (400);
                }

                var result = await _Mediator.Send (new DeletedCustomerOrderDto () { Id = id });

                return StatusCode (204);

            } catch (NotFoundException e) {

                return StatusCode (404, e.Message);

            }

        }

    }
}