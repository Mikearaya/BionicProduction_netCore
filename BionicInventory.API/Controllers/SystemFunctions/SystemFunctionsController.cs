/*
 * @CreateTime: Jan 26, 2019 7:25 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 26, 2019 7:30 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Interfaces;
using BionicInventory.Application.Models;
using BionicInventory.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.SystemFunctions {
    [InventoryAPI ("features")]
    public class SystemFunctionsController : Controller {
        private readonly ISystemFunctionDiscovery _system;

        public SystemFunctionsController (ISystemFunctionDiscovery systemFunctions) {
            _system = systemFunctions;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType (200)]
        [ProducesResponseType (500)]
        public ActionResult<IEnumerable<MvcControllerInfo>> GetSystemFunctionsList () {
            return StatusCode (200, _system.GetFunctions ());
        }
    }
}