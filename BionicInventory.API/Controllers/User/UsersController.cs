/*
 * @CreateTime: Jan 25, 2019 9:52 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 26, 2019 8:00 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BionicInventory.Application.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.Application.Users.Models;
using BionicInventory.Application.Users.Queries.Collections;
using BionicInventory.Application.Users.Queries.Single;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using BionicInventory.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BionicInventory.API.Controllers.User {
    [InventoryAPI ("users")]
    public class UsersController : Controller {
        private readonly IMediator _Mediator;
        private readonly IConfiguration _configuration;

        public UsersController (IMediator mediator,
            IConfiguration configuration) {
            _Mediator = mediator;
            _configuration = configuration;
        }

        [HttpGet ("{id}")]
        [DisplayName ("View User Detail")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<ApplicationUser>> GetUserById (string id) {

            var user = await _Mediator.Send (new GetUserViewByIdQuery () { Id = id });

            return StatusCode (200, user);
        }

        [HttpGet]
        [Authorize]
        [DisplayName ("View Users")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<IActionResult> GetAllUsers () {

            var user = await _Mediator.Send (new GetUsersListViewQuery ());
            return StatusCode (200, user);
        }

        [HttpPost]
        [DisplayName ("Create User")]
        [ProducesResponseType (201)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<IActionResult> CreateUser ([FromBody] NewUserDto newUser) {

            if (newUser == null) {
                return StatusCode (400);
            }

            if (!ModelState.IsValid) {
                return new InvalidInputResponse (ModelState);
            }

            var result = await _Mediator.Send (newUser);

            var user = await _Mediator.Send (new GetUserViewByIdQuery () { Id = result });

            var key = new SymmetricSecurityKey (Encoding.UTF8.GetBytes (_configuration["Jwt:Key"]));
            var creds = new SigningCredentials (key, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim> {
                new Claim (ClaimTypes.NameIdentifier, newUser.userName),
                new Claim (ClaimTypes.Name, newUser.userName)
            };

            var token = new JwtSecurityToken (_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires : DateTime.Now.AddMinutes (30),
                signingCredentials : creds);

            var serializedToken = new { token = new JwtSecurityTokenHandler ().WriteToken (token) };

            return StatusCode (201, serializedToken);
        }

        [HttpPut ("{id}")]
        [DisplayName ("Update User")]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public async Task<IActionResult> UpdateUser ([FromBody] UpdatedUserDto updatedUser) {
            try {

                if (updatedUser == null) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
                }
                var asss = await _Mediator.Send (updatedUser);

                return StatusCode (204);
            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }

        [HttpDelete ("{id}")]
        [DisplayName ("Delete Users")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<IActionResult> DeleteUser (string id) {

            try {
                var user = await _Mediator.Send (new DeletedUserDto () { Id = id });
                return StatusCode (204);
            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }
        }
    }
}