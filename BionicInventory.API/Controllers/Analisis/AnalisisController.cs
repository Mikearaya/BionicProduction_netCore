/*
 * @CreateTime: Nov 21, 2018 11:15 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 21, 2018 11:15 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Analisis.Interfaces;
using BionicInventory.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BionicInventory.API.Controllers.Analisis {
    [InventoryAPI ("analisis")]
    public class AnalisisController : Controller {
        private readonly IDashboardQuery _query;
        private readonly ILogger<AnalisisController> _logger;

        public AnalisisController (IDashboardQuery query,
            ILogger<AnalisisController> logger) {
            _query = query;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult GetBasicSystemStatstics () {
            var status = _query.GetCurrentActivityStats ();
            return StatusCode (200, status);
        }

    }
}