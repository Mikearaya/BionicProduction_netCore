using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using BionicInventory.Application.Models;
using BionicInventory.Commons;
using BionicInventory.DataStore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BionicInventory.API.Controllers.User {
    [InventoryAPI ("users")]
    public class UsersController : Controller {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public UsersController (UserManager<ApplicationUser> userManager,
            IConfiguration configuration) {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpGet ("{id}")]
        [DisplayName ("View User Detail")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<ApplicationUser>> GetUserById (string id) {

            var user = await _userManager.Users
                .Where (u => u.Id == id)
                .FirstOrDefaultAsync ();

            if (user == null) {
                return StatusCode (404);
            }

            return StatusCode (200, user);
        }

        [HttpGet]
        [Authorize]
        [DisplayName ("View Users")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<IActionResult> GetAllUsers () {

            var user = await _userManager.Users
                .Select (UserModel.Projection)
                .ToListAsync ();

            if (user == null) {
                return StatusCode (404);
            }

            return StatusCode (200, user);
        }
    }
}