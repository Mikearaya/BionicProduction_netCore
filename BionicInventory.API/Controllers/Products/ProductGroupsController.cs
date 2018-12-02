/*
 * @CreateTime: Dec 2, 2018 1:57 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 2, 2018 7:43 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BionicInventory.Application.Products.ProductGroups.Commands;
using BionicInventory.Application.Products.ProductGroups.Interfaces;
using BionicInventory.Application.Products.ProductGroups.Models;
using BionicInventory.Application.Products.ProductGroups.Models.Views;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BionicInventory.API.Controllers.Products {

    [InventoryAPI ("products/groups/")]
    public class ProductGroupsController : Controller {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductGroupsController> _logger;
        private readonly IProductGroupCommand _command;
        private readonly IProductGroupQuery _query;
        private readonly IProductGroupFactory _factory;

        public ProductGroupsController (
            ILogger<ProductGroupsController> logger,
            IProductGroupQuery query,
            IProductGroupCommand command,
            IProductGroupFactory factory,
            IMediator mediator
        ) {
            _mediator = mediator;
            _logger = logger;
            _command = command;
            _query = query;
            _factory = factory;
        }

        [HttpGet]
        [ProducesResponseType (200)]
        [ProducesResponseType (500)]
        public ActionResult<IEnumerable<ProductGroupView>> GetProductGroups () {

            var groups = _query.GetProductGroupsView ();
            return StatusCode (200, groups);

        }

        [HttpGet ("{id}")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public ActionResult<ProductGroupView> GetProductGroupsById (uint id) {

            if (id == 0) {
                return StatusCode (400);
            }

            var groups = _query.GetProductGroupViewById (id);

            if (groups == null) {
                return StatusCode (404);
            }

            return StatusCode (200, groups);

        }

        [HttpPost]
        [ProducesResponseType (201)]
        [ProducesResponseType (400)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public ActionResult<ProductGroupView> CreateNewGroup ([FromBody] NewProductGroupDto newGroup) {

            if (newGroup == null) {
                return StatusCode (400);
            }

            if (!ModelState.IsValid) {
                return new InvalidInputResponse (ModelState);
            }

            if (newGroup.ParentGroup != 0) {
                var group = _query.GetProductGroupById ((uint) newGroup.ParentGroup);

                if (group == null) {
                    ModelState.AddModelError ("Parent Group", $"Parent Group with id: {newGroup.ParentGroup} Doesn't Exist");
                    return new InvalidInputResponse (ModelState);
                }
            }

            var groupObj = _factory.NewProductGroup (newGroup);
            var result = _command.SaveProductGroup (groupObj);

            if (result == null) {
                return StatusCode (500, "Unknown Error Occured try again later");
            }

            return StatusCode (201, result);
        }

        [HttpPut ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public ActionResult UpdateProductGroup (uint id, [FromBody] UpdatedProductGroupDto updatedGroup) {

            if (updatedGroup == null || updatedGroup.Id != id) {
                return StatusCode (400);
            }

            if (!ModelState.IsValid) {
                return new InvalidInputResponse (ModelState);
            }

            var groupExist = _query.GetProductGroupById (id);

            if (groupExist == null) {
                return StatusCode (404, "Product Group Not Found");
            }

            if (updatedGroup.ParentGroup != 0) {
                var group = _query.GetProductGroupById ((uint) updatedGroup.ParentGroup);

                if (group == null) {
                    ModelState.AddModelError ("Parent Group", $"Parent Group with id: {updatedGroup.ParentGroup} Doesn't Exist");
                    return new InvalidInputResponse (ModelState);
                }
            }

            var groupObj = _factory.UpdatedProductGroup (groupExist, updatedGroup);
            var result = _command.UpdateProductGroup (groupObj);

            if (result == false) {
                return StatusCode (500, "Unknown Error Occured try again later");
            }

            return StatusCode (204);
        }

        [HttpDelete ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (423)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> DeleteProductGroup (uint id) {
            try {

                await _mediator.Send (new DeleteProductGroupCommand () { Id = id });

                return StatusCode (204);

            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);

            } catch (DbUpdateException) {

                return StatusCode (423, "Can not delete product group with id: {id}, because its being used for other data");

            } catch (Exception e) {
                return StatusCode (500, "Unknown error occured try again later!");
            }

        }

    }
}