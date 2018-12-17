/*
 * @CreateTime: Dec 17, 2018 9:20 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 17, 2018 11:02 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using BionicInventory.Application.Routings.Commands.Create;
using BionicInventory.Application.Routings.Commands.Delete;
using BionicInventory.Application.Routings.Commands.Update;
using BionicInventory.Application.Routings.Models;
using BionicInventory.Application.Routings.Queries.Collections;
using BionicInventory.Application.Routings.Queries.Single;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.Products {

    [InventoryAPI ("products")]
    public class RoutingController : Controller {
        private readonly IMediator _Mediator;

        public RoutingController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpGet ("routings")]
        [ProducesResponseType (200)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<RoutingView>>> GetRoutingList () {

            var routings = await _Mediator.Send (new GetRoutingListQuery ());

            return StatusCode (200, routings);
        }

        [HttpGet ("{itemId}/routings")]
        [ProducesResponseType (200)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<RoutingView>>> GetProductRoutingList (uint itemId) {

            var routings = await _Mediator.Send (new GetProductRoutingListQuery () { ItemId = itemId });

            return StatusCode (200, routings);
        }

        [HttpGet ("{itemId}/routings/{id}")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<RoutingDetailView>> GetItemRoutingDetailById (uint itemId, uint id) {

            try {

                if (itemId == 0 || id == 0) {
                    return StatusCode (400);
                }
                var routing = await _Mediator.Send (new GetRoutingDetailQuery () { Id = id });

                return StatusCode (200, routing);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        [HttpGet ("routings/{id}")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<RoutingDetailView>> GetRoutingDetailById (uint id) {

            try {

                if (id == 0) {
                    return StatusCode (400);
                }
                var routing = await _Mediator.Send (new GetRoutingDetailQuery () { Id = id });

                return StatusCode (200, routing);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        [HttpPost ("{itemId}/routings")]
        [ProducesResponseType (201)]
        [ProducesResponseType (404)]
        [ProducesResponseType (400)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<RoutingDetailView>> CreateProductRouting (uint itemId, [FromBody] NewRoutingDto newRouting) {

            try {
                if (newRouting.ItemId != itemId || newRouting == null) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                var routing = await _Mediator.Send (newRouting);

                return StatusCode (201, routing);
            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }

        }

        [HttpPut ("{itemId}/routings/{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (404)]
        [ProducesResponseType (400)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> UpdateProductRouting (uint itemId, uint id, [FromBody] UpdatedRoutingDto updatedRouting) {

            try {
                if (updatedRouting.ItemId != itemId || updatedRouting == null || id != updatedRouting.Id) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                await _Mediator.Send (updatedRouting);

                return StatusCode (204);
            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }

        }

        [HttpDelete ("{itemId}/routings/{id}")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<RoutingDetailView>> DeleteProductRouting (uint itemId, uint id) {

            try {

                if (itemId == 0 || id == 0) {
                    return StatusCode (400);
                }
                var routing = await _Mediator.Send (new DeletedRoutingDto () { Id = id });

                return StatusCode (204);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

    }
}