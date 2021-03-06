/*
 * @CreateTime: Dec 30, 2018 7:38 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 30, 2019 9:01 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using BionicInventory.Application.Shared;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Stocks.StockLots.Commands.Create;
using BionicInventory.Application.Stocks.StockLots.Models;
using BionicInventory.Application.Stocks.StockLots.Queries.Collection;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.Inventory.StockBatchs {

    [InventoryAPI ("inventory/stock-lots")]
    [DisplayName ("Stock lot")]
    public class StockBatchController : Controller {
        private readonly IMediator _Mediator;

        public StockBatchController (IMediator mediator) {
            _Mediator = mediator;
        }

        // api/inventory/stock-lots
        [HttpGet]
        [DisplayName ("View stock lots list")]
        [ProducesResponseType (200)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<StockBatchListView>>> GetAllStockBatchs () {

            var stockBatchs = await _Mediator.Send (new GetStockBatchListQuery ());

            return StatusCode (200, stockBatchs);

        }

        // api/inventory/stock-lots/2
        [HttpGet ("{id}")]
        [DisplayName ("View stock lot detail")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<StockBatchDetailView>> GetStockBatchById (uint id) {

            try {
                if (id == 0) {
                    return StatusCode (400);
                }

                var batch = await _Mediator.Send (new GetStockBatchDetailViewQuery () { Id = id });

                return StatusCode (200, batch);
            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }

        }

        // api/inventory/stock-lots/items/2
        [HttpGet ("items/{itemId}")]
        [AllowAnonymous]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<StockLotView>>> GetItemStockBatchs (uint itemId) {

            try {
                if (itemId == 0) {
                    return StatusCode (400);
                }

                var batch = await _Mediator.Send (new GetItemStockBatchsQuery () { ItemId = itemId });

                return StatusCode (200, batch);
            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        // api/inventory/stock-lots/items/2
        [HttpGet ("{lotId}/storages")]
        [AllowAnonymous]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<StockLotStorageView>>> GetStockLotStorages (uint lotId) {

            try {
                if (lotId == 0) {
                    return StatusCode (400);
                }

                var lot = await _Mediator.Send (new GetStockLotStoragesQuery () { LotId = lotId });

                return StatusCode (200, lot);
            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ///  api/inventory/stock-lots/count
        [HttpGet ("count")]
        [DisplayName ("View inventory report")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<InventoryView>>> GetInventoryDetail () {

            try {

                var inventory = await _Mediator.Send (new GetInventoryViewQuery ());

                return StatusCode (200, inventory);
            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newBatch"></param>
        /// <returns></returns>
        ///   api/inventory/stock-lots
        [HttpPost]
        [DisplayName ("Create new stock lot")]
        [ProducesResponseType (201)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<StockBatchDetailView>> CreateStockBatch ([FromBody] NewStockBatchDto newBatch) {

            try {

                if (newBatch == null) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                var result = await _Mediator.Send (newBatch);

                var createdBatch = await _Mediator.Send (new GetStockBatchDetailViewQuery () { Id = result });

                return StatusCode (201, createdBatch);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            } catch (BelowRequiredMinimumItemException e) {
                ModelState.AddModelError ("Storage", e.Message);
                return new InvalidInputResponse (ModelState);
            } catch (InequalMasterDetailQuantityException e) {
                ModelState.AddModelError ("Storage", e.Message);
                return new InvalidInputResponse (ModelState);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedBatch"></param>
        /// <returns></returns>
        ///   api/inventory/stock-lots/2
        [HttpPut ("{id}")]
        [DisplayName ("Update stock lot")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> UpdateStockBatch (uint id, [FromBody] UpdatedStockBatchDto updatedBatch) {

            try {

                if (updatedBatch == null || updatedBatch.Id != id || id == 0) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                await _Mediator.Send (updatedBatch);

                return StatusCode (204);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ///   api/inventory/stock-lots/count
        [HttpDelete ("{id}")]
        [DisplayName ("Delete stock lot")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> DeleteStockBatchById (uint id) {

            try {
                if (id == 0) {
                    return StatusCode (400);
                }

                var batch = await _Mediator.Send (new DeletedStockBatchDto () { Id = id });

                return StatusCode (204);
            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        [HttpPost ("movements")]
        [DisplayName ("Movement Stock lot")]
        [ProducesResponseType (201)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<StockBatchDetailView>> CreateNewStockMovement ([FromBody] StockLotMovementDto lotMovement) {

            try {

                if (lotMovement == null) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                var result = await _Mediator.Send (lotMovement);

                if (result == 0) {
                    return StatusCode (500);
                }

                var updatedLot = await _Mediator.Send (new GetStockBatchDetailViewQuery () { Id = result });

                return StatusCode (201, updatedLot);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);

            } catch (QuantityGreaterThanAvailableException e) {
                ModelState.AddModelError ("Quantity", e.Message);
                return new InvalidInputResponse (ModelState);

            } catch (DuplicateStorageLocationMovementException e) {
                ModelState.AddModelError ("Storage", e.Message);
                return new InvalidInputResponse (ModelState);
            }

        }
    }
}