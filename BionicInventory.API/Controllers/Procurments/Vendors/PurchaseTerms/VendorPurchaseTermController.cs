/*
 * @CreateTime: Dec 24, 2018 10:09 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 24, 2018 10:09 PM
 * @Description: Modify Here, Please 
 */
using System.Threading.Tasks;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Vendors.PurchaseTerms.Commands.Create;
using BionicInventory.Application.Vendors.PurchaseTerms.Commands.Delete;
using BionicInventory.Application.Vendors.PurchaseTerms.Commands.Update;
using BionicInventory.Application.Vendors.PurchaseTerms.Models;
using BionicInventory.Application.Vendors.PurchaseTerms.Queries.Single;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.Procurments.Vendors.PurchaseTerms {

    [InventoryAPI ("procurments/purchaseterms")]
    public class VendorPurchaseTermController : Controller {
        private readonly IMediator _Mediator;

        public VendorPurchaseTermController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<VendorPurchaseTermView>> GetAllPurchaseTerms (uint id) {

            try {
                if (id == 0) {
                    return StatusCode (400);
                }
                var purchaseTerm = await _Mediator.Send (new GetVendorPurchaseTermByIdQuery () { Id = id });

                return StatusCode (200, purchaseTerm);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }

        }

        [HttpPut ("purchaseterms/{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> updatePurchaseTerm (uint id, [FromBody] UpdatedVendorPurchaseTermDto updatedPurchaseTerm) {

            try {

                if (id == 0 || updatedPurchaseTerm == null) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                var result = await _Mediator.Send (updatedPurchaseTerm);

                return StatusCode (204);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }

        }

        [HttpDelete ("purchaseterms/{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> deletePurchaseTerm (uint id) {

            try {

                if (id == 0) {
                    return StatusCode (400);
                }

                var result = await _Mediator.Send (new DeletedVendorPurchaseTermDto () { Id = id });

                return StatusCode (204);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }

        }
    }
}