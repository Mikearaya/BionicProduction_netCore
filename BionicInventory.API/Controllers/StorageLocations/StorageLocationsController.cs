/*
 * @CreateTime: Dec 13, 2018 1:12 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 13, 2018 1:27 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.StorageLocations.Commands.Create;
using BionicInventory.Application.StorageLocations.Commands.Delete;
using BionicInventory.Application.StorageLocations.Commands.Update;
using BionicInventory.Application.StorageLocations.Models;
using BionicInventory.Application.StorageLocations.Queries.Collections;
using BionicInventory.Application.StorageLocations.Queries.Single;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.StorageLocations {

    [InventoryAPI ("storages")]
    public class StorageLocationsController : Controller {
        private readonly IMediator _Mediator;

        public StorageLocationsController (IMediator mediator) {
            _Mediator = mediator;
        }

        // api/storages
        [HttpGet]
        [ProducesResponseType (200)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<StorageLocationView>>> GetAllStorageLocations () {

            var storageLocation = await _Mediator.Send (new StorageLocationListQuery ());

            return StatusCode (200, storageLocation);
        }

        // api/storages/1
        [HttpGet ("{id}")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<StorageLocationView>> GetStorageLocationById (uint id) {

            if (id == 0) {
                return StatusCode (400);
            }

            var storageLocation = await _Mediator.Send (new SingleStorageLocationViewQuery () { Id = id });

            return StatusCode (200, storageLocation);
        }

        // api/storages
        [HttpPost]
        [ProducesResponseType (201)]
        [ProducesResponseType (400)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> CreateStorageLocation ([FromBody] NewStorageLocationDto newLocation) {

            if (newLocation == null) {
                return StatusCode (400);
            }

            if (!ModelState.IsValid) {
                return new InvalidInputResponse (ModelState);
            }

            var storageLocation = await _Mediator.Send (newLocation);

            return StatusCode (201);
        }

        // api/storages/1
        [HttpPut ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> UpdateStorageLocation (uint id, [FromBody] UpdatedStorageLocationDto updatedLocation) {

            if (updatedLocation == null || updatedLocation.Id != id) {
                return StatusCode (400);
            }

            if (!ModelState.IsValid) {
                return new InvalidInputResponse (ModelState);
            }
            try {
                var storageLocation = await _Mediator.Send (updatedLocation);

                return StatusCode (204);
            } catch (NotFoundException e) {

                return StatusCode (404, e.Message);
            }
        }

        // api/storages/1
        [HttpDelete ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> DeleteStorageLocation (uint id) {

            if (id == 0) {
                return StatusCode (400);
            }

            try {
                var storageLocation = await _Mediator.Send (new DeletedStorageLocationDto () { Id = id });

                return StatusCode (204);
            } catch (NotFoundException e) {

                return StatusCode (404, e.Message);
            }
        }
    }
}