/*
 * @CreateTime: Dec 3, 2018 9:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 4, 2018 8:01 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.UnitOfMeasurments.Commands.Create;
using BionicInventory.Application.UnitOfMeasurments.Commands.Delete;
using BionicInventory.Application.UnitOfMeasurments.Commands.Update;
using BionicInventory.Application.UnitOfMeasurments.Models;
using BionicInventory.Application.UnitOfMeasurments.Queries;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.Products.UnitOfMeasurments {
    // api/products/uom
    [InventoryAPI ("products/uom")]
    public class UnitOfMeasurmentController : Controller {
        private readonly IMediator _Mediator;

        public UnitOfMeasurmentController (IMediator mediator) {
            _Mediator = mediator;
        }

        // api/products/uom/
        [HttpGet]
        [ProducesResponseType (200)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<UnitOfMeasurmentView>>> GetAllUnitOfMeasurments () {

            var uoms = await _Mediator.Send (new UnitOfMeasurmentListQuery ());

            return StatusCode (200, uoms);

        }

        // api/products/uom/1
        [HttpGet ("{id}")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<UnitOfMeasurmentView>> GetUnitOfMeasurmentById (uint id) {

            try {
                var uom = await _Mediator.Send (new SingleUnitOfMeasurmentQuery () { Id = id });

                return StatusCode (200, uom);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }

        }

        // api/products/uom
        [HttpPost]
        [ProducesResponseType (201)]
        [ProducesResponseType (400)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> CreateUnitOfMeasure ([FromBody] NewUnitOfMeasureDto newUom) {

            if (newUom == null) {
                return StatusCode (400);
            }

            if (!ModelState.IsValid) {
                return new InvalidInputResponse (ModelState);
            }

            await _Mediator.Send (newUom);

            return StatusCode (201);

        }

        // api/products/uom/1
        [HttpPut ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (400)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> UpdateUnitOfMeasure (uint id, [FromBody] UpdatedUnitOfMeasurmentDto updatedUom) {

            try {
                if (updatedUom == null || id != updatedUom.Id) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                await _Mediator.Send (updatedUom);

                return StatusCode (204);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }

        }

        // api/products/uom/1
        [HttpDelete ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> UpdateUnitOfMeasure (uint id) {

            try {
                if (id == 0) {
                    return StatusCode (400);
                }

                await _Mediator.Send (new DeletedUnitOfMeasurmentDto () { Id = id });

                return StatusCode (204);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }

        }
    }
}