/*
 * @CreateTime: Jan 25, 2019 11:47 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 11:58 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using BionicInventory.Application.Security.Roles.Models;
using BionicInventory.Application.Security.Roles.Queries.Collections;
using BionicInventory.Application.Security.Roles.Queries.Single;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Securities.Roles {
    public class RolesController : Controller {
        private readonly IMediator _Mediator;

        public RolesController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        [DisplayName ("View System Role")]
        [ProducesResponseType (200)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<RoleViewModel>>> GetAllUserRoles () {
            var roles = await _Mediator.Send (new GetRoleListViewQuery ());
            return StatusCode (200, roles);

        }

        [HttpGet ("{id}")]
        [AllowAnonymous]
        [DisplayName ("View System Role")]
        [ProducesResponseType (200)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<RoleViewModel>> GetRoleById (string id) {
            var role = await _Mediator.Send (new GetRoleByIdQuery () { Id = id });
            return StatusCode (200, role);

        }

        [HttpPost]
        [DisplayName ("Create Role")]
        [ProducesResponseType (201)]
        [ProducesResponseType (422)]
        [ProducesResponseType (400)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<RoleViewModel>> Create ([FromBody] NewRoleDto newRole) {

            if (newRole == null) {
                return StatusCode (400);
            }
            if (!ModelState.IsValid) {
                return StatusCode (422);
            }

            var result = await _Mediator.Send (newRole);

            var role = await _Mediator.Send (new GetRoleByIdQuery () { Id = result });

            return StatusCode (201, role);
        }

        [HttpPut ("{id}")]
        [DisplayName ("Delete Role")]
        [ProducesResponseType (204)]
        [ProducesResponseType (422)]
        [ProducesResponseType (400)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> UpdateRole ([FromBody] UpdatedRoleDto updatedRole) {

            if (updatedRole == null) {
                return StatusCode (400);
            }
            if (!ModelState.IsValid) {
                return StatusCode (422);
            }

            var result = await _Mediator.Send (updatedRole);

            return StatusCode (204);
        }

        [HttpDelete ("{id}")]
        [DisplayName ("Delete Role")]
        [ProducesResponseType (204)]
        [ProducesResponseType (422)]
        [ProducesResponseType (400)]
        [ProducesResponseType (500)]
        public async Task<ActionResult> DeleteRole (string id) {

            var result = await _Mediator.Send (new DeletedRoleDto () { Id = id });
            return StatusCode (204);
        }
    }
}