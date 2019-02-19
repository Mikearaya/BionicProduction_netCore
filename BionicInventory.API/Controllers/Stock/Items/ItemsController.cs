/*
 * @CreateTime: Sep 1, 2018 9:05 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 7, 2019 3:01 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using BionicInventory.Application.Products.BOMs.Queries.Collection;
using BionicInventory.Application.Products.BOMs.Queries.Models;
using BionicInventory.Application.Products.Interfaces;
using BionicInventory.Application.Products.Models;
using BionicInventory.Application.Products.Queries;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Stocks.Items.Models;
using BionicInventory.Application.Stocks.Items.Queries.Collections;
using BionicInventory.Application.Stocks.Items.Queries.Single;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using BionicInventory.Domain.Items;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.Stock.Items {
    [InventoryAPI ("stocks/items")]
    [DisplayName ("Items")]
    public class ItemsController : Controller {

        public IMediator _Mediator { get; }

        public ItemsController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpGet ("{id}")]
        [DisplayName ("View item detail")]
        [ProducesResponseType (200)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<ItemView>> GetItemById (uint id) {

            if (id == 0) {
                return StatusCode (400);
            }

            try {

                var item = await _Mediator.Send (new GetItemByIdQuery () { Id = id });
                return StatusCode (200, item);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }

        }

        [HttpGet]
        [DisplayName ("View items list")]
        [ProducesResponseType (200)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<ItemView>>> GetAllItemsList () {

            try {

                var itemsList = await _Mediator.Send (new GetItemsLIstQuery ());
                return StatusCode (200, itemsList);

            } catch (Exception e) {

                return StatusCode (500, e.Message);
            }
        }

        [HttpGet ("reports")]
        [DisplayName ("View items report")]
        [ProducesResponseType (200)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<ItemReportListView>>> GetAllItemsReport () {

            try {

                var itemsList = await _Mediator.Send (new GetItemsReportQuery ());
                return StatusCode (200, itemsList);

            } catch (Exception e) {

                return StatusCode (500, e.Message);
            }
        }

        [HttpGet ("critical")]
        [DisplayName ("View critical items list")]
        [ProducesResponseType (200)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<CriticalItemsView>>> GetAllCriticslItemsList (string type = "ALL") {

            try {
                var itemsList = await _Mediator.Send (new GetCriticalItemsListQuery () { Type = type });
                return StatusCode (200, itemsList);

            } catch (Exception e) {

                return StatusCode (500, e.Message);
            }
        }

        [HttpGet ("{id}/critical")]
        [DisplayName ("View critical item detail")]
        [ProducesResponseType (200)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<CriticalItemsView>> GetCriticalItemById (uint id) {

            if (id == 0) {
                return StatusCode (400);
            }

            try {

                var criticalItem = await _Mediator.Send (new GetCriticalItemByIdQuery () { Id = id });
                return StatusCode (200, criticalItem);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }

        }

        [HttpGet ("{itemCode}/unique")]
        [DisplayName ("Check item code uniqueness")]
        [AllowAnonymous]
        [ProducesResponseType (200)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<CriticalItemsView>> CheckItemCodeUniqueness (IsItemCodeUniqueQuery query) {

            if (query == null) {
                return StatusCode (400);
            }

            if (!ModelState.IsValid) {
                return new InvalidInputResponse (ModelState);
            }

            return StatusCode (200, await _Mediator.Send (query));

        }

        // api/id/boms
        [HttpGet ("{id}/boms")]
        [AllowAnonymous]
        [DisplayName ("View item bom list")]
        [ProducesResponseType (200)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<BomView>>> GetItemBoms (uint id) {

            if (id == 0) {
                return StatusCode (400);
            }

            try {

                var itemBom = await _Mediator.Send (new ItemBomViewQuery () { ItemId = id });
                return StatusCode (200, itemBom);

            } catch (NotFoundException e) {

                return StatusCode (404, e.Message);
            }
        }

        // api/products/vendors/3
        [HttpGet ("vendors/{vendorId}")]
        [DisplayName ("View vendor items list")]
        [ProducesResponseType (200)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<BomView>>> GetVendorItemsList (uint vendorId) {

            if (vendorId == 0) {
                return StatusCode (400);
            }

            try {

                var vendorItems = await _Mediator.Send (new GetVendorItemsList () { VendorId = vendorId });
                return StatusCode (200, vendorItems);

            } catch (NotFoundException e) {

                return StatusCode (404, e.Message);
            }
        }

        [HttpPost]
        [DisplayName ("Create Item")]
        [ProducesResponseType (201)]
        [ProducesResponseType (422)]
        [ProducesResponseType (409)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<ItemView>> AddProduct ([FromBody] NewItemDto newProduct) {
            try {

                if (newProduct == null) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }
                var result = await _Mediator.Send (newProduct);

                var view = _Mediator.Send (new GetItemByIdQuery () { Id = result });

                return StatusCode (201, view);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            } catch (DuplicateKeyException e) {
                ModelState.AddModelError ("Code", e.Message);
                return new InvalidInputResponse (ModelState);
            } catch (Exception) {
                return StatusCode (500, "Server Error, Try Again Later");
            }
        }

        [HttpPut ("{id}")]
        [DisplayName ("Update item")]
        [ProducesResponseType (204)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> UpdateProductRecord (uint id, [FromBody] UpdatedItemDto updatedData) {

            try {

                if (updatedData == null) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }

                await _Mediator.Send (updatedData);

                return StatusCode (204);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        [HttpDelete ("{id}")]
        [DisplayName ("Delete item")]
        [ProducesResponseType (204)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> DeleteItem (uint id) {
            try {

                if (id == 0) {
                    return StatusCode (400);
                }

                await _Mediator.Send (new DeletedItemDto () { Id = id });
                return StatusCode (204);

            } catch (Exception) {
                return StatusCode (500, "Server Error, Try Again Later");
            }
        }

    }
}