using Microsoft.AspNetCore.Identity;

namespace BionicInventory.Application.Security.Roles.Models {
    public class ApplicationRole : IdentityRole {
        public string Access { get; set; }
    }
}