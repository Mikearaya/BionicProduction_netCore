/*
 * @CreateTime: Dec 24, 2018 8:40 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 26, 2018 9:10 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Vendors.Commands.Create;
using BionicInventory.Application.Vendors.Commands.Delete;
using BionicInventory.Application.Vendors.Commands.Update;
using BionicInventory.Application.Vendors.Models;
using BionicInventory.Application.Vendors.PurchaseTerms.Commands.Create;
using BionicInventory.Application.Vendors.PurchaseTerms.Commands.Delete;
using BionicInventory.Application.Vendors.PurchaseTerms.Commands.Update;
using BionicInventory.Application.Vendors.PurchaseTerms.Models;
using BionicInventory.Application.Vendors.PurchaseTerms.Queries.Collections;
using BionicInventory.Application.Vendors.PurchaseTerms.Queries.Single;
using BionicInventory.Application.Vendors.Queries.Collections;
using BionicInventory.Application.Vendors.Queries.Single;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.Procurments.Vendors {

    [InventoryAPI ("procurments/vendors")]
    public class VendorsController : Controller {
        private readonly IMediator _Mediator;

        public VendorsController (IMediator mediator) {
            _Mediator = mediator;
        }

        // api/procurments/vendors
        [HttpGet]
        [ProducesResponseType (200)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<VendorView>>> GetAllVendors () {

            var vendorList = await _Mediator.Send (new GetVendorsListQuery ());

            return StatusCode (200, vendorList);
        }

        // api/procurments/vendors/2
        [HttpGet ("{id}")]
        [ProducesResponseType (200)]
        [ProducesResponseType (404)]
        [ProducesResponseType (400)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<VendorView>> GetVendorById (uint id) {

            try {
                if (id == 0) {
                    return StatusCode (400);
                }

                var vendor = await _Mediator.Send (new GetVendorByIdQuery () { Id = id });
                return StatusCode (200, vendor);
            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        // api/procurments/vendors
        [HttpPost]
        [ProducesResponseType (201)]
        [ProducesResponseType (400)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<VendorView>> AddVendor ([FromBody] NewVendorDto newVendor) {
            try {
                if (newVendor == null) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                var result = await _Mediator.Send (newVendor);

                var newVendorView = await _Mediator.Send (new GetVendorByIdQuery () { Id = result });

                return StatusCode (201, newVendorView);
            } catch (DuplicateTinNumberException e) {
                ModelState.AddModelError ("TinNumber", e.Message);
                return new InvalidInputResponse (ModelState);
            }

        }

        // api/procurments/vendors/2
        [HttpPut ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> UpdateVendor (uint id, [FromBody] UpdatedVendorDto updatedVendor) {

            try {

                if (updatedVendor == null || id == 0 || id != updatedVendor.Id) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                var result = await _Mediator.Send (updatedVendor);

                return StatusCode (204);
            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }

        }

        // api/procurments/vendors/2
        [HttpDelete ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> DeleteVendor (uint id) {

            try {

                if (id == 0) {
                    return StatusCode (400);
                }

                var result = await _Mediator.Send (new DeletedVendorDto () { Id = id });

                return StatusCode (204);
            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }

        }

    }
}