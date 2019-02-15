/*
 * @CreateTime: Feb 15, 2019 9:28 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 15, 2019 10:43 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Stocks.Shipments.Models;
using BionicInventory.Application.Stocks.Shipments.Queries.Collection;
using BionicInventory.Application.Stocks.Shipments.Queries.Single;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.Stock.Shipments {
    [InventoryAPI ("stock/shipments")]
    public class ShipmentController : Controller {
        private readonly IMediator _Mediator;

        public ShipmentController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        [DisplayName ("View shipments list")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<ShipmentsListModel>>> GetAllShipments () {

            var shipments = await _Mediator.Send (new GetShipmentsLIstQuery ());

            return StatusCode (200, shipments);
        }

        [HttpGet ("{id}")]
        [Authorize]
        [DisplayName ("View shipment detail")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<ShipmentsListModel>>> GetShipmentById (uint id) {

            if (id == 0) {
                return StatusCode (400);
            }
            try {
                var shipments = await _Mediator.Send (new GetShipmentDetailQuery () { Id = id });

                return StatusCode (200, shipments);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [DisplayName ("Create shipment")]
        [ProducesResponseType (201)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<ShipmentDetailModel>> CreateShipment ([FromBody] NewShipmentDto shipment) {

            if (shipment == null) {
                return StatusCode (400);
            }

            if (!ModelState.IsValid) {
                return new InvalidInputResponse (ModelState);
            }

            try {
                var result = await _Mediator.Send (shipment);
                return StatusCode (201);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        [HttpPut ("{id}")]
        [Authorize]
        [DisplayName ("Update shipment")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> UpdateShipment (uint id, [FromBody] UpdatedShipmentDto updatedShipment) {

            if (updatedShipment == null || updatedShipment.Id != id) {
                return StatusCode (400);
            }

            if (!ModelState.IsValid) {
                return new InvalidInputResponse (ModelState);
            }

            try {

                return StatusCode (201);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        [HttpDelete ("{id}")]
        [Authorize]
        [DisplayName ("Delete shipment")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> DeleteShipment (uint id) {

            if (id == 0) {
                return StatusCode (400);
            }

            try {
                var result = await _Mediator.Send (new DeletedShipmentDto () { Id = id });
                return StatusCode (204);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }
    }
}