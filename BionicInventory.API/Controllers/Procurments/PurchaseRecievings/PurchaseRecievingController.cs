using System.ComponentModel;
using System.Threading.Tasks;
using BionicInventory.Application.Procurments.PurchaseOrders.Models;
using BionicInventory.Application.Procurments.PurchaseOrders.Queries.Single;
using BionicInventory.Application.Procurments.PurchaseRecievings.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.Procurments.PurchaseRecievings {
    [InventoryAPI ("procurments/purchase-recievings")]
    public class PurchaseRecievingController : Controller {
        private readonly IMediator _Mediator;

        public PurchaseRecievingController (IMediator mediator) {

            _Mediator = mediator;
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
        public async Task<ActionResult<PurchaseOrderDetailView>> AddNewPurchaseRecieving ([FromBody] PurchaseRecievingDto newPurchaseRecieving) {

            try {

                if (newPurchaseRecieving == null) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                var purchaseOrderId = await _Mediator.Send (newPurchaseRecieving);

                var purchaseOrderDetail = await _Mediator.Send (new GetPurchaseOrderDetailQuery () { Id = purchaseOrderId });

                return StatusCode (201, purchaseOrderDetail);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }
    }
}