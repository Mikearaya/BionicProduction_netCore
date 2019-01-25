using Microsoft.AspNetCore.Identity;

namespace BionicInventory.Application.Models {
    public class ApplicationRole : IdentityRole {
        public string Access { get; set; }
    }
}