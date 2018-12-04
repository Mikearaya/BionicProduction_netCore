/*
 * @CreateTime: Dec 5, 2018 12:09 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 5, 2018 12:35 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BionicInventory.Application.Products.BOMs.Models;
using BionicInventory.Application.Products.BOMs.Queries.Collection;
using BionicInventory.Application.Products.BOMs.Queries.Models;
using BionicInventory.Application.Products.BOMs.Queries.Single;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.Products {

    [InventoryAPI ("products/boms")]
    public class BillOfMaterialsController : Controller {
        private readonly IMediator _Mediator;

        public BillOfMaterialsController (IMediator mediator) {
            _Mediator = mediator;
        }

        // api/products/boms/1
        [HttpGet]
        [ProducesResponseType (200)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<BomView>>> GetBomList () {

            var bomList = await _Mediator.Send (new BomViewListQuery ());
            return StatusCode (200, bomList);
        }

        // api/products/boms/1
        [HttpGet ("{id}")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<BomView>> GetBomById (uint id) {

            try {

                if (id == 0) {
                    return StatusCode (400);
                }

                var bom = await _Mediator.Send (new SingleBomViewQuery () { Id = id });

                return StatusCode (200, bom);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        // api/products/boms
        [HttpPost]
        [ProducesResponseType (201)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> CreateBillOfMaterial ([FromBody] NewBomDto newBom) {

            try {
                if (newBom == null) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                await _Mediator.Send (newBom);

                return StatusCode (201);

            } catch (NotFoundException e) {

                return StatusCode (404, e.Message);

            }
        }

        // api/products/boms/1
        [HttpPut ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> UpdateBillOfMaterial (uint id, [FromBody] UpdatedBomDto updatedBom) {

            try {
                if (updatedBom == null || id != updatedBom.Id) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                await _Mediator.Send (updatedBom);

                return StatusCode (204);

            } catch (NotFoundException e) {

                return StatusCode (404, e.Message);

            } catch (Exception e) {

                return StatusCode (500, e.Message);
            }
        }

        // api/products/boms/1
        [HttpDelete ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> deleteBillOfMaterial (uint id) {

            try {
                if (id == 0) {
                    return StatusCode (400);
                }

                await _Mediator.Send (new DeletedBomDto () { Id = id });

                return StatusCode (204);

            } catch (NotFoundException e) {

                return StatusCode (404, e.Message);

            } catch (Exception e) {

                return StatusCode (500, e.Message);
            }
        }

    }
}