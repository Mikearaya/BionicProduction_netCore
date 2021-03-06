/*
 * @CreateTime: Jan 1, 2019 10:13 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 9:26 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using BionicInventory.Application.Shared;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Stocks.WriteOffs.Models;
using BionicInventory.Application.Stocks.WriteOffs.Queries.Collections;
using BionicInventory.Application.Stocks.WriteOffs.Queries.Single;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.Inventory.WriteOffs {
    /// <summary>
    /// Handles stock write off adjustment requests
    /// </summary>
    /// 
    [InventoryAPI ("inventory/write-offs")]
    [DisplayName ("Write-off")]
    public class WriteOffsController : Controller {
        private readonly IMediator _Mediator;

        public WriteOffsController (IMediator mediator) {
            _Mediator = mediator;
        }

        /// <summary>
        /// Returns List of written off stock item batch
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [DisplayName ("View write-offs list")]
        [ProducesResponseType (200)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<WriteOffListView>>> GetWriteOffItemsList () {

            var writeOffs = await _Mediator.Send (new GetWriteOffsListQuery ());

            return StatusCode (200, writeOffs);
        }

        [HttpGet ("{id}")]
        [DisplayName ("View write-off detail")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<WriteOffDetailView>> GetWriteOffDetailById (uint id) {

            try {
                if (id == 0) {
                    return StatusCode (400);
                }

                var writeOff = await _Mediator.Send (new GetWriteOffDetailQuery () { Id = id });

                return StatusCode (200, writeOff);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        [HttpPost]
        [DisplayName ("Create stock write-off")]
        [ProducesResponseType (201)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<WriteOffDetailView>> CreateWriteOff ([FromBody] NewWriteOffDto writeOff) {

            try {
                if (writeOff == null) {
                    return StatusCode (400);
                }
                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                var result = await _Mediator.Send (writeOff);

                var newWriteOff = await _Mediator.Send (new GetWriteOffDetailQuery () { Id = result });

                return StatusCode (201, newWriteOff);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            } catch (BelowRequiredMinimumItemException e) {
                ModelState.AddModelError ("Item List", e.Message);
                return new InvalidInputResponse (ModelState);
            } catch (QuantityGreaterThanAvailableException e) {
                ModelState.AddModelError ("Item Quantity", e.Message);
                return new InvalidInputResponse (ModelState);
            }
        }

        [HttpPut ("{id}")]
        [DisplayName ("Update write-off")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> UpdateWriteOff (uint id, [FromBody] UpdatedWriteOffDto updatedWriteOff) {

            try {
                if (updatedWriteOff == null || id == 0 || updatedWriteOff.Id != id) {
                    return StatusCode (400);
                }
                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                var result = await _Mediator.Send (updatedWriteOff);

                return StatusCode (204);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        [HttpDelete ("{id}")]
        [DisplayName ("Delete write-off")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> DeleteWriteOff (uint id) {

            try {
                if (id == 0) {
                    return StatusCode (400);
                }

                await _Mediator.Send (new DeletedWriteOffDto () { Id = id });

                return StatusCode (204);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        [HttpDelete ("{id}/detail/")]
        [DisplayName ("Delete write-off detail")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> DeleteWriteOffDetail (uint id) {

            try {
                if (id == 0) {
                    return StatusCode (400);
                }

                await _Mediator.Send (new DeleteWriteOffDetailDto () { WriteOffDetailId = id });

                return StatusCode (204);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }
    }
}