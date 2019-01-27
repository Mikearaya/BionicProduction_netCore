/*
 * @CreateTime: Oct 16, 2018 11:16 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 16, 2018 11:17 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.ComponentModel;
using BionicInventory.Application.CompanyProfile.Interfaces;
using BionicInventory.Application.CompanyProfile.Iterfaces;
using BionicInventory.Application.CompanyProfile.Models;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BionicInventory.API.Controllers.Employees {

    [InventoryAPI ("companyprofile")]
    [DisplayName ("Company Profile")]
    public class CompanyprofileController : Controller {
        private readonly ICompanyProfileCommands _command;
        private readonly ICompanyProfileQueries _query;
        private readonly ICompanyProfileFactories _factory;
        private readonly ILogger<CompanyprofileController> _logger;

        public CompanyprofileController (ICompanyProfileQueries query,
            ICompanyProfileCommands commands,
            ICompanyProfileFactories factories,
            ILogger<CompanyprofileController> logger) {

            _command = commands;
            _query = query;
            _factory = factories;
            _logger = logger;

        }

        [HttpGet]
        [DisplayName ("View Company Profile")]
        [Authorize]
        [ProducesResponseType (200, Type = typeof (CompanyProfileView))]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (500)]
        public IActionResult GetCompanyProfile () {

            try {
                var profile = _query.GetCompanyProfileView ();
                return StatusCode (200, profile);
            } catch (Exception e) {
                _logger.LogError (500, e.Message);
                return StatusCode (500);
            }

        }

        [HttpPut ("{id}")]
        [DisplayName ("Update Company Profile")]
        [Authorize]
        [ProducesResponseType (204, Type = typeof (bool))]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public IActionResult UpdateCompanyProfile (uint id, [FromBody] UpdatedCompanyProfileDto updatedProfile) {

            if (updatedProfile == null) {
                return StatusCode (400);
            }
            if (!ModelState.IsValid) {
                return new InvalidInputResponse (ModelState);
            }

            var profile = _factory.NewCompany (updatedProfile);
            var result = _command.UpdateProfile (profile);

            if (result == true) {
                return StatusCode (204);
            }

            return StatusCode (500);
        }

    }
}