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
            _query.GetCurrentActivityStats ();
            return StatusCode (200);
        }

    }
}