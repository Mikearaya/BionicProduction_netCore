/*
 * @CreateTime: Jan 10, 2019 10:29 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 18, 2019 9:56 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using BionicInventory.Application.Procurments.PurchaseOrders.Models;
using BionicInventory.Application.Procurments.PurchaseOrders.Queries.Collections;
using BionicInventory.Application.Procurments.PurchaseOrders.Queries.Single;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.Procurments.PurchaseOrders {

    [InventoryAPI ("procurments/purchase-orders")]
    [DisplayName ("Purchase Order")]
    public class PurchaseOrdersController : Controller {
        private readonly IMediator _Mediator;

        public PurchaseOrdersController (IMediator mediator) {

            _Mediator = mediator;
        }

        [HttpGet]
        [DisplayName ("View Purchase Orders List")]
        [ProducesResponseType (200)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<PurchaseOrderListView>>> GetAllPurchaseOrders () {

            var purchaseOrdersList = await _Mediator.Send (new GetPurchaseOrderListQuery ());

            return StatusCode (200, purchaseOrdersList);
        }

        [HttpGet ("{id}")]
        [DisplayName ("View Purchase Order Detail")]

        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<PurchaseOrderDetailView>> GetPurchaseOrderById (uint id) {

            if (id == 0) {
                return StatusCode (400);
            }

            try {

                var purchaseOrder = await _Mediator.Send (new GetPurchaseOrderDetailQuery () { Id = id });

                return StatusCode (200, purchaseOrder);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        [HttpPost]
        [DisplayName ("Create Purchase Order")]
        [ProducesResponseType (201)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<PurchaseOrderDetailView>> CreateNewPurchaseOrder ([FromBody] NewPurchaseOrderDto newPurchaseOrder) {

            try {

                if (newPurchaseOrder == null) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                var purchaseOrderId = await _Mediator.Send (newPurchaseOrder);

                var purchaseOrderDetail = await _Mediator.Send (new GetPurchaseOrderDetailQuery () { Id = purchaseOrderId });

                return StatusCode (201, purchaseOrderDetail);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        [HttpPut ("{id}")]
        [DisplayName ("Update Purchase Order")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> UpdatePurchaseOrder (uint id, [FromBody] UpdatedPurchaseOrderDto updatedPurchaseOrder) {

            try {

                if (updatedPurchaseOrder == null ||
                    id == 0 ||
                    id != updatedPurchaseOrder.Id) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                await _Mediator.Send (updatedPurchaseOrder);

                return StatusCode (204);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        [HttpDelete ("{id}")]
        [DisplayName ("Delete Purchase Order")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> DeletePurchaseOrder (uint id) {

            try {

                if (id == 0) {
                    return StatusCode (400);
                }

                await _Mediator.Send (new DeletedPurchaseOrderDto () { Id = id });

                return StatusCode (204);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        [HttpPost ("quotations")]
        [DisplayName ("Create Purchase Order")]
        [ProducesResponseType (201)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<PurchaseOrderDetailView>> CreateNewPurchaseQuotation ([FromBody] NewPurchaseQuotationDto newPurchaseOrder) {

            try {

                if (newPurchaseOrder == null) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                var purchaseOrderId = await _Mediator.Send (newPurchaseOrder);

                var purchaseOrderDetail = await _Mediator.Send (new GetPurchaseOrderDetailQuery () { Id = purchaseOrderId });

                return StatusCode (201, purchaseOrderDetail);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

    }
}