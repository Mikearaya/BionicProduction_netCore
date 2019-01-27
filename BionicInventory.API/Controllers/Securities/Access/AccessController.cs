using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BionicInventory.Application.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using BionicInventory.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace BionicInventory.API.Controllers.Securities.Access {
    [InventoryAPI ("")]
    public class AccessController : Controller {
        private readonly IConfiguration _configuration;
        private readonly IMediator _Mediator;

        public AccessController (IMediator mediator,
            IConfiguration configuration) {
            _configuration = configuration;
            _Mediator = mediator;
        }

        [HttpPost ("login")]
        [ProducesResponseType (200)]
        [ProducesResponseType (500)]
        [ProducesResponseType (400)]
        [ProducesResponseType (422)]
        public async Task<ActionResult> LogIn ([FromBody] AuthenticationQuery userAuth) {

            if (userAuth == null) {
                return StatusCode (400);
            }

            if (!ModelState.IsValid) {
                return new InvalidInputResponse (ModelState);
            }

            try {
                var user = await _Mediator.Send (userAuth);
                var key = new SymmetricSecurityKey (Encoding.UTF8.GetBytes (_configuration["jwt:key"]));
                var creds = new SigningCredentials (key, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim> {
                    new Claim (ClaimTypes.NameIdentifier, user.userName),
                    new Claim (ClaimTypes.Name, user.userName)
                };
                var identity = new ClaimsIdentity (claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal (identity);
                var token = new JwtSecurityToken (_configuration["jwt:Issuer"],
                    _configuration["jwt:Audience"],
                    claims,
                    expires : DateTime.Now.AddMinutes (30),
                    signingCredentials : creds);
                var serializedToken = new { token = new JwtSecurityTokenHandler ().WriteToken (token) };

                return StatusCode (200, serializedToken);

            } catch (NotFoundException e) {
                ModelState.AddModelError ("Username or password", e.Message);
                return new InvalidInputResponse (ModelState);
            }

        }
    }
}